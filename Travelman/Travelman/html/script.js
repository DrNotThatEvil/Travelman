var directionsDisplay, directionsService, map;

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

function showRoute(start, end) {
    var request = {
        origin: start,
        destination: end,
        travelMode: 'DRIVING'
    };
    directionsService.route(request, function(result, status) {
        if (status === 'OK') {
            directionsDisplay.setDirections(result);
        }
    });
}