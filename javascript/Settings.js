		function setBasicProperties(){
			setPizzaSize();
			setGriedientSize();
			setCamera();
			setControls();
			setCanvas();
			setScene();
			setLight();
			setRendering();

		}

		function setPizzaSize(){
			 sizePizza= { small:200,medium:300,big:500, presentSize:0}
		}
		function setGriedientSize(){
			 sizeGriedient= { half:Math.PI, whole:Math.PI*2 }
		}

		function setRendering(){

			renderer = new THREE.WebGLRenderer( { antialias: true, canvas: container} );
			renderer.setSize( 800, 600 );
			renderer.setClearColor( 0xf0f0f0 );
			renderer.setPixelRatio( window.devicePixelRatio );
			renderer.setSize( window.innerWidth, window.innerHeight );
			renderer.sortObjects = false;

			renderer.shadowMap.enabled = true;
			renderer.shadowMap.type = THREE.PCFShadowMap;
			renderer.domElement.addEventListener( 'mousemove', onDocumentMouseMove, false );
			renderer.domElement.addEventListener( 'mousedown', onDocumentMouseDown, false );
			renderer.domElement.addEventListener( 'mouseup', onDocumentMouseUp, false );

			controls.enabled = false;
			window.addEventListener( 'resize', onWindowResize, false );
		}


		function setCamera(){
			camera = new THREE.PerspectiveCamera( 70, window.innerWidth / window.innerHeight, 1, 10000 );
			camera.position.z = 1000;
		}

		function setCanvas(){
			container = document.getElementById('canvas') ;
		}

		function setScene(){
			scene = new THREE.Scene();
		}
		function setLight(){			
			var light = new THREE.SpotLight( 0xffffff, 1.5 );
			light.position.set( 0, 500, 2000 );
			light.castShadow = true;
			light.shadow = new THREE.LightShadow( new THREE.PerspectiveCamera( 50, 1, 200, 10000 ) );
			light.shadow.bias = - 0.00022;
			light.shadow.mapSize.width = 2048;
			light.shadow.mapSize.height = 2048;

			scene.add( light );
			scene.add( new THREE.AmbientLight( 0x505050 ) );
		}

		function setControls(){
			controls = new THREE.TrackballControls( camera );
			controls.rotateSpeed = 1.0;
			controls.zoomSpeed = 1.2;
			controls.panSpeed = 0.8;
			controls.noZoom = false;
			controls.noPan = false;
			controls.staticMoving = true;
			controls.dynamicDampingFactor = 0.3;
		}

		function onWindowResize() {

				camera.aspect = window.innerWidth / window.innerHeight;
				camera.updateProjectionMatrix();

				renderer.setSize( window.innerWidth, window.innerHeight );

		}

		function onDocumentMouseMove( event ) {

			event.preventDefault();
			mouse.x = ( event.clientX / window.innerWidth ) * 2 - 1;
			mouse.y = - ( event.clientY / window.innerHeight ) * 2 + 1;
			raycaster.setFromCamera( mouse, camera );
			if ( SELECTED ) {
				if ( raycaster.ray.intersectPlane( plane, intersection ) ) {
					SELECTED.position.copy( intersection.sub( offset ) );
				}
			return;
			}

			var intersects = raycaster.intersectObjects( objects );

			if ( intersects.length > 0   ) {

				if ( INTERSECTED != intersects[ 0 ].object ) {

					if ( INTERSECTED ) INTERSECTED.material.color.setHex( INTERSECTED.currentHex );

						INTERSECTED = intersects[ 0 ].object;
						INTERSECTED.currentHex = INTERSECTED.material.color.getHex();

						plane.setFromNormalAndCoplanarPoint(
							camera.getWorldDirection( plane.normal ),
							INTERSECTED.position );

					}

					container.style.cursor = 'pointer';

				} else {

					if ( INTERSECTED ) INTERSECTED.material.color.setHex( INTERSECTED.currentHex );

					INTERSECTED = null;

					container.style.cursor = 'auto';

				}

			}

			function onDocumentMouseDown( event ) {

				event.preventDefault();

				raycaster.setFromCamera( mouse, camera );

				var intersects = raycaster.intersectObjects( objects );

				if ( intersects.length > 0 ) {

					SELECTED = intersects[ 0 ].object;
 
					if ( raycaster.ray.intersectPlane( plane, intersection ) ) {    			 	
	    			 	 	 
	    				 offset.copy( intersection ).sub( SELECTED.position ); 			 		 
					}
					container.style.cursor = 'move';
				}
			}

			function onDocumentMouseUp( event ) {

				event.preventDefault();

				console.log(SELECTED.position.x);
				 
	    		SELECTED.position.x=limitDrag(SELECTED.position.x,sizePizza.presentSize);
	    		SELECTED.position.y=limitDrag(SELECTED.position.y,sizePizza.presentSize);

				if ( INTERSECTED ) {
					SELECTED = null;
				}
				container.style.cursor = 'auto';
			}

			function limitDrag(position, limit)
			{
 
				if(position>limit){
					return limit;
				}
				else if (position<(0-limit)) {
					return (0-limit);
				}
				else{
					return position;
				}
			}