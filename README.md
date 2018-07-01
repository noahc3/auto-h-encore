# auto h-encore
A C# (.NET) application to automate (most of) the process of getting h-encore running on your PS Vita system!

![screenshot](https://puu.sh/APlvB/66bb81d982.png "screenshot")

## Features
This application does everything short of installing QCMA/integrating libVitaMTP. That means:

 - Automatically downloads required tools (psvimgtools, pkg2img, bittersmile demo and h-encore itself)
 - Grabs CMA encryption key from your account ID
 - Unpackages bittersmile and repackages it with your encryption key and h-encore
 - Moves finished files to your QCMA directory for copying to your PS Vita
 
This application **does not**:
 
 - Get your AID automatically
 - Send h-encore to your PS Vita
 
Basically, you still need QCMA.

## Usage

The application has been tested on an OLED 3G Vita. Newer models and PSTV are untested.

Download and extract the [latest release](https://github.com/noahc3/auto-h-encore/releases "latest release") and run it. Further instructions are included in the application itself. QCMA is required to get your AID and transfer h-encore to your Vita.

If the application crashes or h-encore fails to install, please [submit an issue](http://https://github.com/noahc3/auto-h-encore/issues "submit an issue"), **do not create an issue on the h-encore Github**, it probably isn't their fault.

## Build

Clone the repository and open the solution in Visual Studio. Build from there.

## Contributing

I don't know C, so I can't reasonably integrate libVitaMTP into the application to fully automate the process. If you can do this, I would greatly appreciate it if you could fork and/or submit a pull request to implement this functionality. 

The code also needs some cleanup and error handling.

Other changes are also welcome through pull requests.