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

Start the server before starting any clients as the client will try to connect to the server after choosing a name.