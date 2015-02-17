<?php

class Room implements iReservable {
    private $roomType;
    private $hasRestroom;
    private $hasBalcony;
    private $bedCount;
    private $roomNumber;
    private $price;
    private $extras;
    private $reservations;

    function __construct($roomNumber, $roomType, $bedCount, $hasRestroom, $hasBalcony, $price, ...$extras) {
        $this->setRoomNumber($roomNumber);
        $this->setRoomType($roomType);
        $this->setBedCount($bedCount);
        $this->setHasRestroom($hasRestroom);
        $this->setHasBalcony($hasBalcony);
        $this->setPrice($price);
        $this->setExtras($extras);

        $this->reservations = [];
    }

    public function getBedCount()
    {
        return $this->bedCount;
    }

    private function setBedCount($bedCount)
    {
        $this->bedCount = $bedCount;
    }

    public function getHasBalcony()
    {
        return $this->hasBalcony;
    }

    private function setHasBalcony($hasBalcony)
    {
        $this->hasBalcony = $hasBalcony;
    }

    public function getHasRestroom()
    {
        return $this->hasRestroom;
    }

    private function setHasRestroom($hasRestroom)
    {
        $this->hasRestroom = $hasRestroom;
    }

    public function getPrice()
    {
        return $this->price;
    }

    private function setPrice($price)
    {
        $this->price = $price;
    }

    public function getReservations()
    {
        return $this->reservations;
    }

    public function getRoomNumber()
    {
        return $this->roomNumber;
    }

    private function setRoomNumber($roomNumber)
    {
        $this->roomNumber = $roomNumber;
    }

    public function getRoomType()
    {
        return $this->roomType;
    }

    private function setRoomType($roomType)
    {
        $this->roomType = $roomType;
    }

    public function getExtras()
    {
        return $this->extras;
    }

    private function setExtras($extras)
    {
        $this->extras = $extras;
    }

    public function addReservation($reservation) {
        array_push($this->reservations, $reservation);
    }

    public function removeReservation($reservation) {
        for ($index = 0; $index < count($this->reservations); $index++) {
            if ($this->reservations[$index] == $reservation) {
                unset($this->reservations[$index]);
                break;
            }
        }
    }

    public function __toString() {
        $output = "";
        $output .="Room Number: " . $this->roomNumber . "</br>";
        $output .="Room Type: " . $this->roomType . "</br>";
        $output .="Has Restroom: " . $this->hasRestroom . "</br>";
        $output .="Has Balcony: " . $this->hasBalcony . "</br>";
        $output .="Bed Count: " . $this->bedCount . "</br>";
        $output .="Price: " . $this->price . "</br>";
        $output .="Extras: " . implode(", ", $this->extras) . "</br>";
        $output .="Reservations:</br> " . implode("</br>\t", $this->reservations) . "</br>";

        return $output;
    }
} 