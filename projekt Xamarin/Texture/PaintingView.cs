using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

using OpenTK.Graphics;
using OpenTK.Graphics.ES11;
using OpenTK.Platform;
using OpenTK.Platform.Android;
using OpenTK;

using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;

namespace Mono.Samples.TexturedCube
{

    class PaintingView : AndroidGameView
    {

        const int angleOfChange = 330;
        float prevx, prevy;
        float xangle, yangle;
        int[] textureIds;
        int cur_texture;
        int width, height;
        Context context;
        public static int[] TexturesResourcesInts;
        public PaintingView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public PaintingView(IntPtr handle, Android.Runtime.JniHandleOwnership transfer)
            : base(handle, transfer)
        {
            Initialize();
        }

        private void Initialize()
        {

            context = Context;
            xangle = 0;
            yangle = 0;
            TexturesResourcesInts = new int[]
		    {
		        Resource.Drawable.photo3,Resource.Drawable.photo4,Resource.Drawable.photo5,Resource.Drawable.photo6,
                Resource.Drawable.photo7,Resource.Drawable.photo8,Resource.Drawable.photo9,Resource.Drawable.photo10,
                Resource.Drawable.photo11,Resource.Drawable.photo12,Resource.Drawable.photo13,Resource.Drawable.photo14,
                Resource.Drawable.photo15,Resource.Drawable.photo16,Resource.Drawable.photo17,Resource.Drawable.photo18,
                Resource.Drawable.photo19,Resource.Drawable.photo20,Resource.Drawable.photo21,Resource.Drawable.photo22,
                Resource.Drawable.photo23,Resource.Drawable.photo24,Resource.Drawable.photo25
		    };
            textureIds = new int[TexturesResourcesInts.Length];
            Resize += delegate
            {
                height = Height;
                width = Width;
                SetupCamera();
                RenderCube();
            };
        }

        // This method is called everytime the context needs
        // to be recreated. Use it to set any egl-specific settings
        // prior to context creation
        protected override void CreateFrameBuffer()
        {
            ContextRenderingApi = GLVersion.ES1;

            // the default GraphicsMode that is set consists of (16, 16, 0, 0, 2, false)
            try
            {
                Log.Verbose("TexturedCube", "Loading with default settings");

                // if you don't call this, the context won't be created
                base.CreateFrameBuffer();
                return;
            }
            catch (Exception ex)
            {
                Log.Verbose("TexturedCube", "{0}", ex);
            }

            try
            {
                Log.Verbose("TexturedCube", "Loading with custom Android settings (low mode)");
                GraphicsMode = new AndroidGraphicsMode(16, 0, 0, 0, 0, false);

                // if you don't call this, the context won't be created
                base.CreateFrameBuffer();
                return;
            }
            catch (Exception ex)
            {
                Log.Verbose("TexturedCube", "{0}", ex);
            }

            try
            {
                Log.Verbose("TexturedCube", "Loading with no Android settings");
                GraphicsMode = new AndroidGraphicsMode(0, 4, 0, 0, 0, false);

                // if you don't call this, the context won't be created
                base.CreateFrameBuffer();
                return;
            }
            catch (Exception ex)
            {
                Log.Verbose("TexturedCube", "{0}", ex);
            }
            throw new Exception("Can't load egl, aborting");
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ShadeModel(All.Smooth);
            GL.ClearColor(0, 0, 0, 1);

            GL.ClearDepth(1.0f);
            GL.Enable(All.DepthTest);
            GL.DepthFunc(All.Lequal);

            GL.Enable(All.CullFace);
            GL.CullFace(All.Back);

            GL.Hint(All.PerspectiveCorrectionHint, All.Nicest);

            // create texture ids
            GL.Enable(All.Texture2D);
            GL.GenTextures( TexturesResourcesInts.Length, textureIds);

            for (var i = 0; i < TexturesResourcesInts.Length; i++)
            {
                LoadTexture(context, TexturesResourcesInts[i], textureIds[i]);
            }
            SetupCamera();
            RenderCube();
        }

        void SetupCamera()
        {
            width = Width;
            height = Height;

            GL.Viewport(0, 0, width, height);
            // setup projection matrix
            GL.MatrixMode(All.Projection);
            GL.LoadIdentity();

            // gluPerspective
            Matrix4 m = Matrix4.CreatePerspectiveFieldOfView(ToRadians(45.0f), (float)width / (float)height, 1.0f, 100.0f);
            float[] perspective_m = new float[16];

            int i = 0;
            perspective_m[i + 0] = m.Row0.X; perspective_m[i + 1] = m.Row0.Y;
            perspective_m[i + 2] = m.Row0.Z; perspective_m[i + 3] = m.Row0.W;
            i += 4;

            perspective_m[i + 0] = m.Row1.X; perspective_m[i + 1] = m.Row1.Y;
            perspective_m[i + 2] = m.Row1.Z; perspective_m[i + 3] = m.Row1.W;
            i += 4;

            perspective_m[i + 0] = m.Row2.X; perspective_m[i + 1] = m.Row2.Y;
            perspective_m[i + 2] = m.Row2.Z; perspective_m[i + 3] = m.Row2.W;
            i += 4;

            perspective_m[i + 0] = m.Row3.X; perspective_m[i + 1] = m.Row3.Y;
            perspective_m[i + 2] = m.Row3.Z; perspective_m[i + 3] = m.Row3.W;

            GL.LoadMatrix(perspective_m);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            base.OnTouchEvent(e);
            if (e.Action == MotionEventActions.Down)
            {
                prevx = e.GetX();
                prevy = e.GetY();
            }
            if (e.Action == MotionEventActions.Move)
            {
                float e_x = e.GetX();
                float e_y = e.GetY();

                float xdiff = (prevx - e_x);
                float ydiff = (prevy - e_y);
                xangle = xangle + ydiff;
                yangle = yangle + xdiff;
                prevx = e_x;
                prevy = e_y;
                ChangingBackTexture(xangle, yangle);

            }
            if (e.Action == MotionEventActions.Down || e.Action == MotionEventActions.Move)
                RenderCube();
            return true;
        }

        private void ChangingBackTexture(float xangle, float yangle)
        {
            var  tempX = System.Math.Abs(xangle - 90) % angleOfChange;
            var  tempY = System.Math.Abs(yangle) % angleOfChange;

            if ((tempX > 0 && tempX < 20) && (tempY > 0 && tempY < 20))
            {
                textureIds[0] = RandomizeTexture();
            }

            tempX = System.Math.Abs(xangle + 90) % angleOfChange;
            tempY = System.Math.Abs(yangle) % angleOfChange;

            if ((tempX > 0 && tempX < 20) && (tempY > 0 && tempY < 20))
            {
                textureIds[1] = RandomizeTexture();
            }

            tempX = System.Math.Abs(xangle) % angleOfChange;
            tempY = System.Math.Abs((yangle + 180)) % angleOfChange;

            if ((tempX > 0 && tempX < 60) && (tempY > 0 && tempY < 60))
            {
                textureIds[2] = RandomizeTexture();
            }

           tempX = System.Math.Abs(xangle) % angleOfChange;
            tempY = System.Math.Abs(yangle) % angleOfChange;

            if ((tempX > 0 && tempX < 60) && (tempY > 0 && tempY < 60))
            {
                textureIds[3] = RandomizeTexture();
            }

            tempX = System.Math.Abs(xangle) % angleOfChange;
            tempY = System.Math.Abs((yangle - 90)) % angleOfChange;

            if ((tempX > 0 && tempX < 60) && (tempY > 0 && tempY < 60))
            {
                textureIds[4] = RandomizeTexture();
            }

            tempX = System.Math.Abs(xangle) % angleOfChange;
            tempY = System.Math.Abs((yangle + 90)) % angleOfChange;

            if ((tempX > 0 && tempX < 60) && (tempY > 0 && tempY < 60))
            {
                textureIds[5] = RandomizeTexture();
            }
    }

        protected override void OnUnload(EventArgs e)
        {
            GL.DeleteTextures(6, textureIds);
        }

        public void SwitchTexture()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            textureIds = textureIds.Select(item => new { item, order = rnd.Next() })
            .OrderBy(x => x.order)
            .Select(x => x.item)
            .ToArray();
            RenderCube();
        }
        public int RandomizeTexture()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return textureIds[rnd.Next(0, textureIds.Length)];

        }


        void RenderCube()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(All.Modelview);
            GL.LoadIdentity();
            GL.Translate(0, 0, -6);
            GL.Rotate(-xangle, 1, 0, 0);
            GL.Rotate(-yangle, 0, 1, 0);
            GL.EnableClientState(All.VertexArray);
            GL.EnableClientState(All.TextureCoordArray);

            for (int i = 0; i < 6; i++) // draw each face
            {
                GL.BindTexture(All.Texture2D, textureIds[i]);
                float[] v = cubeVertexCoords[i];
                float[] t = cubeTextureCoords[i];
                GL.VertexPointer(3, All.Float, 0, v);
                GL.TexCoordPointer(2, All.Float, 0, t);
                GL.DrawArrays(All.TriangleFan, 0, 4);
                GL.Finish();
            }
            GL.DisableClientState(All.VertexArray);
            GL.DisableClientState(All.TextureCoordArray);

            SwapBuffers();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            GL.DeleteTextures(6, textureIds);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RenderCube();
        }

        public static float ToRadians(float degrees)
        {
            //pi/180
            //FIXME: precalc pi/180
            return (float)(degrees * (System.Math.PI / 180.0));
        }

        void LoadTexture(Context context, int resourceId, int tex_id)
        {
            GL.BindTexture(All.Texture2D, tex_id);

            // setup texture parameters
            GL.TexParameterx(All.Texture2D, All.TextureMagFilter, (int)All.Linear);
            GL.TexParameterx(All.Texture2D, All.TextureMinFilter, (int)All.Linear);
            GL.TexParameterx(All.Texture2D, All.TextureWrapS, (int)All.ClampToEdge);
            GL.TexParameterx(All.Texture2D, All.TextureWrapT, (int)All.ClampToEdge);

            Bitmap b = BitmapFactory.DecodeResource(context.Resources, resourceId);

            Android.Opengl.GLUtils.TexImage2D((int)All.Texture2D, 0, b, 0);
        }


        static float[][] cubeVertexCoords = new float[][] {
			new float[] { // top
				 1, 1,-1,
				-1, 1,-1,
				-1, 1, 1,
				 1, 1, 1
			},
			new float[] { // bottom
				 1,-1, 1,
				-1,-1, 1,
				-1,-1,-1,
				 1,-1,-1
			},
			new float[] { // front
				 1, 1, 1,
				-1, 1, 1,
				-1,-1, 1,
				 1,-1, 1
			},
			new float[] { // back
				 1,-1,-1,
				-1,-1,-1,
				-1, 1,-1,
				 1, 1,-1
			},
			new float[] { // left
				-1, 1, 1,
				-1, 1,-1,
				-1,-1,-1,
				-1,-1, 1
			},
			new float[] { // right
				 1, 1,-1,
				 1, 1, 1,
				 1,-1, 1,
				 1,-1,-1
			},
		};

        static float[][] cubeTextureCoords = new float[][] {
			new float[] { // top
				1, 0,
				1, 1,
				0, 1,
				0, 0
			},
			new float[] { // bottom
				0, 0,
				1, 0,
				1, 1,
				0, 1
			},
			new float[] { // front
				1, 1,
				0, 1,
				0, 0,
				1, 0
			},
			new float[] { // back
				0, 1,
				0, 0,
				1, 0,
				1, 1
			},
			new float[] { // left
				1, 1,
				0, 1,
				0, 0,
				1, 0
			},
			new float[] { // right
				0, 1,
				0, 0,
				1, 0,
				1, 1
			},
		};


    }
}
