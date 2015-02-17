<?php

function __autoload($className) {
    include_once("./Rooms/" . $className . ".class.php");
}

include_once("Exceptions/EReservationException.class.php");
include_once("Interfaces/iReservable.class.php");
include_once("Enumerations/RoomType.class.php");
include_once("Reservation.class.php");
include_once("Guest.class.php");
include_once("Controllers/BookingManager.class.php");

$reservation = new Reservation(date("17-02-2014"), date("19-02-2014"), new Guest("Pesho", "Ivanov", 1));
$anotherReservation = new Reservation(date("20-02-2014"), date("23-02-2014"), new Guest("Another", "Guy", 1));
$room = new SingleRoom(200, 100);

BookingManager::bookRoom($room, $reservation);
BookingManager::bookRoom($room, $anotherReservation);

var_dump($room->getReservations());

$room->removeReservation($anotherReservation);

echo $room;

var_dump($room->getReservations());

echo "</br>LAMBDA OPERATIONS:</br>";

$array = array(
    new SingleRoom(1, 200),
    new Apartment(2, 230),
    new Bedroom(3, 300),
    new Bedroom(4, 350),
    new Apartment(5, 330),
    new SingleRoom(6, 120)
);

$cheapApartmentsAndBedrooms = array_filter($array, function($n) {
    return (get_class($n) == "Bedroom" ||
        get_class($n) == "Apartment") &&
        $n->getPrice() <= 250;
});

echo "</br>Cheap Apartments and Bedrooms</br></br>";
echo implode("</br>", $cheapApartmentsAndBedrooms);

$roomsWithBalconies = array_filter($array, function($n) {
    return $n->getHasBalcony();
});

echo "</br>Rooms With Balcony</br></br>";
echo implode("</br>", $roomsWithBalconies);

$roomsWithBathTub = array_filter($array, function($n) {
    return in_array("Bathtub", $n->getExtras());
});

$roomNumbers = array_map(function($v) {
    return $v->getRoomNumber();
}, $roomsWithBathTub);

echo "</br>Room Numbers of Rooms With Bathtub</br></br>";
echo implode("</br>", $roomNumbers);

$startDatePeriod = "17-02-2014";
$endDatePeriod = "20-02-2014";

$reservation = new Reservation($startDatePeriod, $endDatePeriod, new Guest("Petar", "Ivanov", 2));
echo "</br></br>";
BookingManager::bookRoom($array[1], $reservation);

$roomsNotBookedInPeriod = array_filter($array,
    function($r) use ($startDatePeriod, $endDatePeriod) {
        $isApartment = get_class($r) == "Apartment";
        $isNotBookedInPeriod = true;
        for ($index = 0; $index < count($r->getReservations()); $index++) {
            $currentReservationStartDate = strtotime($r->getReservations()[$index]->getStartDate());
            $currentReservationEndDate = strtotime($r->getReservations()[$index]->getEndDate());
            $startDate = strtotime($startDatePeriod);
            $endDate = strtotime($endDatePeriod);
            if (($currentReservationStartDate >= $startDate &&
                    $currentReservationStartDate <= $endDate) ||
                    ($currentReservationEndDate >= $startDate &&
                    $currentReservationEndDate <= $endDate)) {
                $isNotBookedInPeriod = false;
                break;
            }
        }

        return $isApartment && $isNotBookedInPeriod;
    }
);

echo "</br>Apartments not booked in period $startDatePeriod : $endDatePeriod</br></br>";
echo implode("</br>", $roomsNotBookedInPeriod);