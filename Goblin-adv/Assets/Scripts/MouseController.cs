using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;
public class MouseController :MonoBehaviour
    {
        private Ray _ray;
        private Transform _craftedObject;
        private bool _craftActive;
        private Camera _camera;
        [SerializeField] private Player _player;
        private Vector3 _attackCenter;
        private Vector3 _screenCenter;
        private Vector3 _attackVector3;

        private void Start()
        {
            _camera = Camera.main;
            _screenCenter.x = _camera.pixelWidth/2;
            _screenCenter.y = _camera.pixelHeight/2;
            _attackCenter = _player.transform.position;
        }

        public void StartCrafting(Transform transform)
        {
            _craftedObject = transform;
            _craftActive = true;
        }

        public void StopCrafting()
        {
            if (_craftActive)
            {
                Destroy(_craftedObject.gameObject);
                _craftActive = false;
            }
        }

        public void CompleteCrafting()
        {
            _craftedObject = null;
            _craftActive = false;
        }

        void Update()
        {
            if(_craftActive){
                _ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out var hit))
                {
                    _craftedObject.position =new Vector3(hit.point.x,_player.transform.position.y,hit.point.z);
                }
                if(Input.GetMouseButtonDown(1))
                {
                    StopCrafting();
                }

                if (Input.GetMouseButtonDown(0))
                {
                    CompleteCrafting();
                }
                
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _attackVector3 = (Input.mousePosition - _screenCenter).normalized;
                    _attackCenter.x = _player.transform.position.x + _attackVector3.x;
                    _attackCenter.z = _player.transform.position.z + _attackVector3.y;
                    _player.DealAttack(_attackCenter);
                }
            }
            
            
           

        }
       
    }
