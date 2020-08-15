using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using Unity.Physics;

namespace Hex.Render
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class HexMesh : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Mesh hexMesh;
        [SerializeField] private UnityEngine.Material hexMaterial;

        UnityEngine.MeshCollider meshCollider;
        Entity entity;

        void Awake()
        {
            GetComponent<MeshFilter>().mesh = hexMesh = new UnityEngine.Mesh();
            meshCollider = gameObject.AddComponent<UnityEngine.MeshCollider>();
            hexMesh.name = "Hex Mesh";

            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            EntityArchetype hexMeshArchetype = entityManager.CreateArchetype(
                typeof(LocalToWorld),
                typeof(RenderMesh),
                typeof(RenderBounds),
                typeof(HexMeshTag),
                typeof(PhysicsCollider),
                typeof(Translation),
                typeof(Rotation)
            );

            entity = entityManager.CreateEntity(hexMeshArchetype);

            entityManager.SetSharedComponentData(entity, new RenderMesh {
                mesh = hexMesh,
                material = hexMaterial
            });
        }

        void Update() {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var render = entityManager.GetSharedComponentData<RenderMesh>(entity);

            hexMesh = render.mesh;
        }
    }
}
