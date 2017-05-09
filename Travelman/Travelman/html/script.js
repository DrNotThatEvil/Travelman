var directionsDisplay, directionsService, map, markers = [];

function initialize() {
    // Due to callback being succesful we do not need to check global variable availability
    document.getElementById("error").style.display = "none";
    document.getElementById("map").style.display = "block";
    directionsService = new google.maps.DirectionsService();
    directionsDisplay = new google.maps.DirectionsRenderer();
    var nl = new google.maps.LatLng(52.3745913, 4.828575);
    var mapOptions = {
        zoom: 7,
        center: nl
    };
    map = new google.maps.Map(document.getElementById('map'), mapOptions);
    directionsDisplay.setMap(map);
}

function clearMarkers() {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(null);
    }
    markers = [];
}

function showRoute(start, end) {
    clearMarkers();
    var request = {
        origin: start,
        destination: end,
        travelMode: 'DRIVING'
    };
    directionsService.route(request,
        function(result, status) {
            if (status === 'OK') {
                directionsDisplay.setDirections(result);
            }
        });
    console.log(directionsDisplay);
}

function addMarker(lat, lng, label) {
    console.log("I think I created marker with label" + label);
    var marker = new google.maps.Marker({
        position: { lat: lat, lng: lng },
        label: label,
        map: directionsDisplay.map
    });
    console.log("Actual: " + marker.label);
    markers.push(marker);
}

function selectMarker(index) {
    // Note that parameter is not zero-indexed, while the array is
    if (markers[index] !== null) {
        directionsDisplay.map.setCenter(markers[index - 1].position);
    }
}