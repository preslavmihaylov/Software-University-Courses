<?php

class BookingManager {
    public static function bookRoom($room, $reservation) {
        for ($index = 0; $index < count($room->getReservations()); $index++) {
            $roomStartDate = strtotime($room->getReservations()[$index]->getStartDate());
            $roomEndDate = strtotime($room->getReservations()[$index]->getEndDate());
            $reservationStartDate = strtotime($reservation->getStartDate());
            $reservationEndDate = strtotime($reservation->getEndDate());

            if (($roomStartDate >= $reservationStartDate &&
                $roomStartDate <= $reservationEndDate) ||
                ($roomEndDate >= $reservationStartDate &&
                $roomEndDate <= $reservationEndDate)) {

                throw new EReservationException();
            }
        }

        $room->addReservation($reservation);
        $firstName = $reservation->getGuest()->getFirstName();
        $lastName = $reservation->getGuest()->getLastName();
        $startDate = $reservation->getStartDate();
        $endDate = $reservation->getEndDate();

        echo "Room <strong>1408</strong>
            successfully booked for <strong>$firstName $lastName</strong>
            from <time>$startDate</time>
            to <time>$endDate</time>!</br>";
    }
} 