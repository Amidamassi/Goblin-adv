using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;
using UnityEngine.EventSystems;
public class MouseController :MonoBehaviour
    {
        private Ray _ray;
        private Transform _craftedObject;
        private bool _craftActive;
        private Camera _camera;
        private Vector3 _attackCenter;
        private Vector3 _screenCenter;
        private Vector3 _attackVector3;
        private Vector3 _hitOnFieldPosition;
        private bool _wrongPlaceForCraft;
        private Renderer _craftedObjectRender;
        private Transform _playerPosition;
        private Action<Vector3> _dealAttackAction;
        private Func<Vector3,Vector3> _placeInCellAction;
        private Func<Vector3, bool> _isPositionEmptyAction;

        public void Initialize(Transform playerPosition)
        {
            _playerPosition = playerPosition;
            _camera = Camera.main;
            _screenCenter.x = _camera.pixelWidth/2;
            _screenCenter.y = _camera.pixelHeight/2;
            _attackCenter = _playerPosition.position;
        }

        public void StartCrafting(Transform transform)
        {
            _craftedObject = transform;
            _craftActive = true;
            _craftedObjectRender = _craftedObject.GetComponent<Renderer>();
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
                    _hitOnFieldPosition =new Vector3(hit.point.x,_playerPosition.position.y,hit.point.z);
                    _craftedObject.position = _placeInCellAction.Invoke(_hitOnFieldPosition);
                    if (_isPositionEmptyAction.Invoke(_hitOnFieldPosition))
                    {
                        _craftedObjectRender.material.color = Color.white;
                        _wrongPlaceForCraft = false;
                    }
                    else
                    {
                        _craftedObjectRender.material.color = Color.red;
                        _wrongPlaceForCraft = true;
                    }
                }
                if(!EventSystem.current.IsPointerOverGameObject()){
                if(Input.GetMouseButtonDown(1))
                {
                    StopCrafting();
                }

                if (Input.GetMouseButtonDown(0))
                {
                    if (_wrongPlaceForCraft)
                    {
                        StopCrafting();
                    }
                    else
                    {
                        CompleteCrafting();
                    }
                }
                }
                
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {

                        _attackVector3 = (Input.mousePosition - _screenCenter).normalized;
                        _attackCenter.x = _playerPosition.position.x + _attackVector3.x;
                        _attackCenter.z = _playerPosition.position.z + _attackVector3.y;
                        _dealAttackAction.Invoke(_attackCenter);
                    }
                }
            }
            
            
           

        }

        public void DealAttack(Action<Vector3> action)
        {
            _dealAttackAction = action;
        }

        public void PlaceInCell(Func<Vector3,Vector3> action)
        {
            _placeInCellAction = action;
        }

        public void IsPositionEmpty(Func<Vector3,bool> action)
        {
            _isPositionEmptyAction = action;
        }
    }
