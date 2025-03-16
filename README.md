# File Handler Application
## Description
This application is a simple file handler application that allows you to read, write, and append content to a file. 
This solution contains two console application. One is file creator console application.
Another one is file processor console application. File creator console application 
generates some random text and writes it to a file. File processor console 
application can read the contents of that file and write it to another file.
## How to run the application 
You can clone the repository and run the application using the following commands:

1. docker build -t filehandler-app .
2. docker run filehandler-app