<?php

class Reservation {
    private $startDate;
    private $endDate;
    private $guest;

    function __construct($startDate, $endDate, $guest) {
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
        $this->setGuest($guest);
    }

    public function getEndDate()
    {
        return $this->endDate;
    }

    private function setEndDate($endDate)
    {
        if ($this->getStartDate() > $endDate) {
            throw new InvalidArgumentException();
        }
        $this->endDate = $endDate;
    }

    public function getGuest()
    {
        return $this->guest;
    }

    private function setGuest($guest)
    {
        $this->guest = $guest;
    }

    public function getStartDate()
    {
        return $this->startDate;
    }

    private function setStartDate($startDate)
    {
        $this->startDate = $startDate;
    }

    public function __toString() {
        $output = "";
        $output .= "Start Date: " . $this->startDate . "</br>";
        $output .= "End Date: " . $this->endDate . "</br>";
        $output .= "Guest: " . $this->guest . "</br>";
        return $output;
    }
} 