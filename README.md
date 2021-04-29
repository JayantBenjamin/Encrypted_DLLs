# Implementing and Using an Encrypted DLL

Foobar is a Python library for dealing with word pluralization.

## Installation

Build the Aescodedomdll.sln and generate Aescodedomdll.dll in the bin folder.


## Usage

Add the generated file as a reference, then build the Torque_App
Torque_App is a simple application to multiply radius, force and angle theta.  
The formula for calculating it is encrypted inside the dll and not available in the raw form.
The user will have to use a key to compile the encrypted function. Hence preventing reverse engineering.

![Torque Window Application](https://raw.githubusercontent.com/JayantBenjamin/Encrypted_DLLs/master/Window_Application.PNG?raw=true)
## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[Creative Commons Zero v1.0 Universal](https://creativecommons.org/publicdomain/zero/1.0/legalcode)
