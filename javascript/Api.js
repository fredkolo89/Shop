function loadTexture(nameOfTexture){

	return new THREE.ImageUtils.loadTexture(nameOfTexture);
}
function JSONLoader(){

	return new THREE.JSONLoader();
}
function loadMaterial(texture){

	return new THREE.MeshBasicMaterial({map: texture});
}
function mesh(geometry, material){

	return new THREE.Mesh( geometry, material);
}
function circle(radius,segments,angle){

	return new THREE.CircleGeometry( radius, segments,0, angle )
}
function createRenderer(){

	return new THREE.WebGLRenderer( { antialias: true, canvas: container} );
}
function createCamera(){

	return new THREE.PerspectiveCamera(70, window.innerWidth / window.innerHeight, 1, 10000);
}
function createScene(){

	return new THREE.Scene();
}
function createSpotLight(){

	return new THREE.SpotLight( 0xffffff, 1.5 );
}
function createLightShadow(){

	return new THREE.LightShadow( new THREE.PerspectiveCamera( 50, 1, 200, 10000 ) );
}
function createAmbientLight(){

	return  new THREE.AmbientLight( 0x505050 );
}
function createTrackballControls(camera){

	return new THREE.TrackballControls( camera );
}
function createPlane(){

	return new THREE.Plane();
}
function createRaycaster(){

	return new THREE.Raycaster();
} 
 

   function download(strData, strFileName, strMimeType) {
    var D = document,
        A = arguments,
        a = D.createElement("a"),
        d = A[0],
        n = A[1],
        t = A[2] || "text/plain";

    //build download link:
    a.href = "data:" + strMimeType + "charset=utf-8," + escape(strData);


    if (window.MSBlobBuilder) { // IE10
        var bb = new MSBlobBuilder();
        bb.append(strData);
        return navigator.msSaveBlob(bb, strFileName);
    } /* end if(window.MSBlobBuilder) */



    if ('download' in a) { //FF20, CH19
        a.setAttribute("download", n);
        a.innerHTML = "downloading...";
        D.body.appendChild(a);
        setTimeout(function() {
            var e = D.createEvent("MouseEvents");
            e.initMouseEvent("click", true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
            a.dispatchEvent(e);
            D.body.removeChild(a);
        }, 66);
        return true;
    }; /* end if('download' in a) */



    //do iframe dataURL download: (older W3)
    var f = D.createElement("iframe");
    D.body.appendChild(f);
    f.src = "data:" + (A[2] ? A[2] : "application/octet-stream") + (window.btoa ? ";base64" : "") + "," + (window.btoa ? window.btoa : escape)(strData);
    setTimeout(function() {
        D.body.removeChild(f);
    }, 333);
    return true;
}
  function getObjectClass(obj){
   if (typeof obj != "object" || obj === null) return false;
   else return /(\w+)\(/.exec(obj.constructor.toString())[1];}