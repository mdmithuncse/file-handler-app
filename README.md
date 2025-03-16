# File Handler Application
## Description
This application is a simple file handler that allows you to read, write, and append to a file. 
It is a command line application that generates some random text and writes it to a file.
Another command line application can read the contents of that file and write it to another file.
## How to run the application
You can clone the repository and run the application using the following command:

1. docker build -t filecreator -f Dockerfile --target runtime-filecreator .
2. docker build -t fileprocessor -f Dockerfile --target runtime-fileprocessor .
3. docker run filecreator
4. docker run fileprocessor