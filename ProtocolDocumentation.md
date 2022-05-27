# Protocol Documentation (Draft)

Protocol's structure:

Message From Pic to RPI:

        1) x Byte -> Pic Id;

        2) 1 Bit -> Status Door Nr° 1;

        3) 1 Bit -> Status Door Nr° 2;

        4) 1 Bit -> Status Door Nr° 1;

        5) 1 Bit -> Status Door Nr° 2;

        6) 1 Bit -> Toilette Status;

        7) x Byte -> Temperature;

        8) x Byte -> Humidity;

        9) x Byte -> Gas Sensor

        10) x Byte -> Other Sensors.

Message From RPI to Pic:

        1) x Byte -> Pic Id;

        2) x Byte -> Command recipient (Door, Toilette, Temperature, Humidity); [Optional]

        3) x Byte -> Command To Exe. [Optional]