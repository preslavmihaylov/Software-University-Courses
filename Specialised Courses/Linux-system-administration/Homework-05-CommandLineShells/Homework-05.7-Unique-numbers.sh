#!/bin/bash
 
awk '{print $3}' $1 | sort -n | uniq
