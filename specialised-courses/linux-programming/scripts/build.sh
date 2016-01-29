#!/bin/bash

aclocal
autoconf
automake --add-missing
./configure
make dist
make distcheck
