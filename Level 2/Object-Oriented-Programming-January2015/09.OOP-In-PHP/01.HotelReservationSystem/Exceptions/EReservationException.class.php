<?php

class EReservationException extends Exception {
    public function __construct() {
        parent::__construct("The reservation already exists.", 101);
    }
}
