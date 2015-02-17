<?php

class Bedroom extends Room {
    function  __construct($roomNumber, $price) {
        parent::__construct(
            $roomNumber,
            RoomType::Gold,
            2,
            true,
            true,
            $price,
            "TV", "Air-Conditioner", "Refrigerator", "Mini-bar", "Bathtub");
    }

} 