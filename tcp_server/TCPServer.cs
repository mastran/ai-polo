using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Sharing.Tests;

#if !UNITY_EDITOR
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
#endif

public class TCPServer : MonoBehaviour {

    // Use this for initialization
    public String _input = "Waiting";
    private SyncObjectSpawner syncObjectSpawner;
    private Queue <String> executionQueue = new Queue<String>();
    public TextMesh textmesh;

#if !UNITY_EDITOR

    StreamSocket socket;
    StreamSocketListener listener;
    String port;
    String message;

#endif

    void Start() {
#if !UNITY_EDITOR
        listener = new StreamSocketListener();
        port = "9090";
        listener.ConnectionReceived += Listener_ConnectionReceived;
        listener.Control.KeepAlive = false;

        Listener_Start();
        syncObjectSpawner = GameObject.Find("SyncObjectSpawner").GetComponent<SyncObjectSpawner>();
#endif
    }

#if !UNITY_EDITOR

    private async void Listener_Start() {
        Debug.Log("Listener started");
        try {
            await
            listener.BindServiceNameAsync(port);
        }
        catch (Exception e) {
            Debug.Log("Error: " + e.Message);
        }

        Debug.Log("Listening");
    }

    private async void
        Listener_ConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args) {
        Debug.Log("Connection received");

        try {

            using (var dw = new DataWriter(args.Socket.OutputStream))
            {
                dw.WriteString("Hello There");
                await
                dw.StoreAsync();
                dw.DetachStream();
            }

            using (var dr = new DataReader(args.Socket.InputStream))
            {
                dr.InputStreamOptions = InputStreamOptions.Partial;
                await
                dr.LoadAsync(30);

                var receivedString = dr.ReadString(30);
                var command = receivedString.Trim();

                lock(executionQueue)
                {
                    executionQueue.Enqueue(command);
                }
            }

        }
        catch (Exception e) {
            Debug.Log("disconnected!!!!!!!! " + e);
        }

    }


#endif
    private Vector3 getVectorPos(string position) {
        var components = position.Split('#');
        return new Vector3(float.Parse(components[0], System.Globalization.CultureInfo.InvariantCulture),
                float.Parse(components[1], System.Globalization.CultureInfo.InvariantCulture),
                float.Parse(components[2], System.Globalization.CultureInfo.InvariantCulture));
    }

    // Update is called once per frame
    void Update() {
        lock(executionQueue)
        {
            while (executionQueue.Count > 0) {

                var content = executionQueue.Dequeue().Split(' ');
                var command = content[0];
                var position = getVectorPos(content[1]);
                var childPosition = getVectorPos(content[2]);
                textmesh.text += "\n received: " + command;
                switch (command) {
                    case "ShowCube":
                        syncObjectSpawner.SpawnBasicSyncObject(position);
                        break;
                    case "ShowSphere":
                        syncObjectSpawner.SpawnCustomSyncObject(position);
                        break;
                    case "ShowFog":
                        syncObjectSpawner.SpawnFog(position);
                        break;
                    case "ShowFire":
                        syncObjectSpawner.SpawnFire(position);
                        break;
                    case "ShowThunder":
                        syncObjectSpawner.SpawnThunderbolt(position);
                        break;
                    case "ShowBeam":
                        syncObjectSpawner.SpawnBeam(position, childPosition);
                        break;
                    case "ShowButterfly":
                        syncObjectSpawner.SpawnButterfly(position);
                        break;
                    case "UpdateBeam":
                        syncObjectSpawner.DeleteBeam();
                        syncObjectSpawner.SpawnBeam(position, childPosition);
                        break;
                    case "DeleteFog":
                        syncObjectSpawner.DeleteFog();
                        break;
                    case "DeleteCube":
                        syncObjectSpawner.DeleteCube();
                        break;
                    case "DeleteThunder":
                        syncObjectSpawner.DeleteThunder();
                        break;
                    case "DeleteFire":
                        syncObjectSpawner.DeleteFire();
                        break;
                    case "DeleteBeam":
                        syncObjectSpawner.DeleteBeam();
                        break;
                    case "DeleteButterfly":
                        syncObjectSpawner.DeleteButterfly();
                        break;

                    default:
                        break;
                }
            }

        }

    }
}
