<?php

class SingleRoom extends Room {
    function __construct($roomNumber, $price) {
        parent::__construct($roomNumber, RoomType::Standard, 1, true, false, $price, "TV", "Air-Conditioner");
    }

} 