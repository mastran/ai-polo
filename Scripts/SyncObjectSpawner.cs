// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Sharing.Tests
{
    /// <summary>
    /// Class that handles spawning sync objects on keyboard presses, for the SpawningTest scene.
    /// </summary>
    public class SyncObjectSpawner : MonoBehaviour
    {
        [SerializeField]
        private PrefabSpawnManager spawnManager = null;

        public TextMesh textmesh;

        [SerializeField]
        [Tooltip("Optional transform target, for when you want to spawn the object on a specific parent.  If this value is not set, then the spawned objects will be spawned on this game object.")]
        private Transform spawnParentTransform;

        private void Awake()
        {
            if (spawnManager == null)
            {
                Debug.LogError("You need to reference the spawn manager on SyncObjectSpawner.");
            }

            // If we don't have a spawn parent transform, then spawn the object on this transform.
            if (spawnParentTransform == null)
            {
                spawnParentTransform = transform;
            }
        }

        public void SpawnBasicSyncObject(Vector3 position)
        {
            Quaternion rotation = Quaternion.identity;
            var spawnedObject = new SyncSpawnedObject();

            spawnManager.Spawn(spawnedObject, position, rotation, null, spawnParentTransform.gameObject, "SpawnedObject", false);
        }

        public void SpawnCustomSyncObject(Vector3 position)
        {
            Quaternion rotation = Random.rotation;

            var spawnedObject = new SyncSpawnTestSphere();
            spawnedObject.TestFloat.Value = Random.Range(0f, 100f);

            spawnManager.Spawn(spawnedObject, position, rotation, spawnParentTransform.gameObject, "SpawnTestSphere", false);
        }

        public void SpawnFog(Vector3 position)
        {
            Quaternion rotation = Random.rotation;

            var spawnedObject = new SyncSpawnFog();
            spawnedObject.TestFloat.Value = Random.Range(0f, 100f);

            spawnManager.Spawn(spawnedObject, position, rotation, spawnParentTransform.gameObject, "SpawnFog", false);
        }

        public void SpawnButterfly(Vector3 position)
        {
            Quaternion rotation = Random.rotation;

            var spawnedObject = new SyncSpawnButterfly();
            spawnedObject.TestFloat.Value = Random.Range(0f, 100f);

            spawnManager.Spawn(spawnedObject, position, rotation, spawnParentTransform.gameObject, "SpawnButterfly", false);
        }


        public void SpawnBeam(Vector3 position, Vector3 childPosition)
        {
            Quaternion rotation = Random.rotation;

            var spawnedObject = new SyncSpawnBeam();
            spawnedObject.TestFloat.Value = Random.Range(0f, 100f);

            spawnManager.Spawn(spawnedObject, position, rotation, spawnParentTransform.gameObject, "SpawnBeam", false, childPosition);
        }

        public void SpawnFire(Vector3 position)
        {
            Quaternion rotation = Quaternion.identity;

            var spawnedObject = new SyncSpawnFire();
            spawnedObject.TestFloat.Value = Random.Range(0f, 100f);

            spawnManager.Spawn(spawnedObject, position, rotation, spawnParentTransform.gameObject, "SpawnFire", false);
        }

        public void SpawnThunderbolt(Vector3 position)
        {
            Quaternion rotation = Random.rotation;

            var spawnedObject = new SyncSpawnThunderbolt();
            spawnedObject.TestFloat.Value = Random.Range(0f, 100f);

            spawnManager.Spawn(spawnedObject, position, rotation, spawnParentTransform.gameObject, "SpawnThunder", false);
        }

        /// <summary>
        /// Deletes any sync object that inherits from SyncSpawnObject.
        /// </summary>
        public void DeleteSyncObject()
        {
            GameObject hitObject = GazeManager.Instance.HitObject;
            if (hitObject != null)
            {
                var syncModelAccessor = hitObject.GetComponent<DefaultSyncModelAccessor>();
                if (syncModelAccessor != null)
                {
                    var syncSpawnObject = (SyncSpawnedObject)syncModelAccessor.SyncModel;
                    spawnManager.Delete(syncSpawnObject);
                }
            }
        }

        public void DeleteCube()
        {
            GameObject cubeObject = GameObject.FindGameObjectWithTag("TestCube");
            if (cubeObject != null)
            {
                textmesh.text += "\n in the cube";
                var syncModelAccessor = cubeObject.GetComponent<DefaultSyncModelAccessor>();
                if (syncModelAccessor != null)
                {
                    textmesh.text += "\n syncmodelavailable";
                    var syncSpawnObject = (SyncSpawnedObject)syncModelAccessor.SyncModel;
                    spawnManager.Delete(syncSpawnObject);
                }
            }
        }

        public void DeleteFog()
        {
            GameObject cubeObject = GameObject.FindGameObjectWithTag("TestFog");
            if (cubeObject != null)
            {
                textmesh.text += "\n in the fog";
                var syncModelAccessor = cubeObject.GetComponent<DefaultSyncModelAccessor>();
                if (syncModelAccessor != null)
                {
                    textmesh.text += "\n syncmodelavailable";
                    var syncSpawnObject = (SyncSpawnFog)syncModelAccessor.SyncModel;
                    spawnManager.Delete(syncSpawnObject);
                }
            }
        }

        public void DeleteButterfly()
        {
            GameObject cubeObject = GameObject.FindGameObjectWithTag("TestButterfly");
            if (cubeObject != null)
            {
                textmesh.text += "\n in the fog";
                var syncModelAccessor = cubeObject.GetComponent<DefaultSyncModelAccessor>();
                if (syncModelAccessor != null)
                {
                    textmesh.text += "\n syncmodelavailable";
                    var syncSpawnObject = (SyncSpawnButterfly)syncModelAccessor.SyncModel;
                    spawnManager.Delete(syncSpawnObject);
                }
            }
        }


        public void DeleteThunder()
        {
            GameObject cubeObject = GameObject.FindGameObjectWithTag("TestThunder");
            if (cubeObject != null)
            {
                textmesh.text += "\n in the thunder";
                var syncModelAccessor = cubeObject.GetComponent<DefaultSyncModelAccessor>();
                if (syncModelAccessor != null)
                {
                    textmesh.text += "\n syncmodelavailable";
                    var syncSpawnObject = (SyncSpawnThunderbolt)syncModelAccessor.SyncModel;
                    spawnManager.Delete(syncSpawnObject);
                }
            }
        }

        public void DeleteFire()
        {
            GameObject cubeObject = GameObject.FindGameObjectWithTag("TestFire");
            if (cubeObject != null)
            {
                textmesh.text += "\n in the fire";
                var syncModelAccessor = cubeObject.GetComponent<DefaultSyncModelAccessor>();
                if (syncModelAccessor != null)
                {
                    textmesh.text += "\n syncmodelavailable";
                    var syncSpawnObject = (SyncSpawnFire)syncModelAccessor.SyncModel;
                    spawnManager.Delete(syncSpawnObject);
                }
            }
        }

        public void DeleteBeam()
        {
            GameObject cubeObject = GameObject.FindGameObjectWithTag("TestBeam");
            if (cubeObject != null)
            {
                textmesh.text += "\n in the fire";
                var syncModelAccessor = cubeObject.GetComponent<DefaultSyncModelAccessor>();
                if (syncModelAccessor != null)
                {
                    textmesh.text += "\n syncmodelavailable";
                    var syncSpawnObject = (SyncSpawnBeam)syncModelAccessor.SyncModel;
                    spawnManager.Delete(syncSpawnObject);
                }
            }
        }
    }
}
