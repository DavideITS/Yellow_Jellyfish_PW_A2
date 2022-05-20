# Protocol Documentation (Draft)

Protocol's structure:

Message From Pic to RPI:

        1) x Byte -> Pic Id;

        2) 1 Bit -> Status Door Nr° 1;

        3) 1 Bit -> Status Door Nr° 2;

        4) 1 Bit -> Toilette Status;

        5) x Byte -> Temperature;

        6) x Byte -> Humidity;

Message From RPI to Pic:

        1) x Byte -> Pic Id;

        2) x Byte -> Command recipient (Door Nr° 1, Door Nr° 2, Toilette, Temperature, Humidity) [Optional]

        3) x Byte -> Command To Exe [Optional]