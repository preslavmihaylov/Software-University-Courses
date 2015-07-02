#!/bin/bash

# Version 1
# lsof | sed -e 's/\s\s*/ /g' | cut -d' ' -f 1,9 | sed -e 's/ / || /'

# Version 2
lsof|awk '{ print $1, "||", $9 }'
