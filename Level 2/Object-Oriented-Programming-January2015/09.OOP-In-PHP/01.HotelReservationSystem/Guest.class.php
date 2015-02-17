<?php

class Guest {
    private $firstName;
    private $lastName;
    private $id;

    function __construct($firstName, $lastName, $id) {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
        $this->setId($id);
    }

    public function getFirstName()
    {
        return $this->firstName;
    }

    private function setFirstName($firstName)
    {
        $this->firstName = $firstName;
    }

    public function getId()
    {
        return $this->id;
    }

    private function setId($id)
    {
        $this->id = $id;
    }

    public function getLastName()
    {
        return $this->lastName;
    }

    private function setLastName($lastName)
    {
        $this->lastName = $lastName;
    }

    public function __toString() {
        $output = "";
        $output .= $this->firstName . " " . $this->lastName . " ID: " . $this->id . ".";
        return $output;
    }
} 