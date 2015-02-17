<?php

class Apartment extends Room {
    function __construct($roomNumber, $price) {
        parent::__construct(
            $roomNumber,
            RoomType::Diamond,
            4,
            true,
            true,
            $price,
            "TV", "Air-Conditioner", "Refrigerator", "Mini-bar", "Bathtub", "Kitchen Box", "Free WI-FI");
    }
} 