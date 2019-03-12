# Chat App

SE3330 Team NullReferenceException

Our project is a chat app that uses a server and a client to connect users and allow them to talk to each other.

## Before running the project

The client and server both rely on Json serializing, the project should already include the necessary libraries. If the libraries are missing, follow these instructions:

In Visual Studios, navigate to 
```
project > Manage NuGet Packages > Browse
```

Search  and install the "Newtonsoft" json library.

## Starting the Application

Open up the Server project and client project Visual Studio.

Build the clients and run the executable from the bin folder to run multiple clients.

Start the server (from the .exe or project, either works) before starting any clients as the client(s) will try to connect to the server after choosing a name.

## Closing the Application

The server does not handle closed connections well so closing a client will require the server to be shutdown and restarted.