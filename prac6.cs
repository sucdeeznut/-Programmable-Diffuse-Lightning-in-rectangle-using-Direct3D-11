using Microsoft.DirectX; //OUR CODE 
using Microsoft.DirectX.Direct3D; //OUR CODE
namespace WindowsFormsApplication8
{
    public partial class Form6 : Form
    {
        Microsoft.DirectX.Direct3D.Device device;
        public Form6()
        {
            InitializeComponent();
            InitDevice();//OUR CODE
        }
 private void Form6_Paint(Object sender, PaintEventArgs e)
        {
            Render();
        }
 private void Form6_Load(object sender, EventArgs e)
        {
        }
        private void InitDevice() //OUR CODE 
        { PresentParameters pp = new PresentParameters(); 
            pp.Windowed = true; 
            pp.SwapEffect = SwapEffect.Discard; 
            device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, pp); 
            device.RenderState.Lighting = false; 
            device.Transform.Projection = Matrix.PerspectiveFovLH(3.14f / 4, device.Viewport.Width / device.Viewport.Height, 1f, 100f); 
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, 10), new Vector3(), new Vector3(0, 1, 0)); 
            device.RenderState.Lighting = true; 
            device.Lights[0].Type = LightType.Directional;
            device.Lights[0].Diffuse = Color.BlanchedAlmond; 
            device.Lights[0].Direction = new Vector3(0.8f, 0, -1); device.Lights[0].Enabled = true; 
        }
        private void Render() //OUR CODE 
        { 
            CustomVertex.PositionNormalColored[] vertexes = new CustomVertex.PositionNormalColored[6]; //6 here is the number of vectors you've defined
//triangle1 
            vertexes[0] = new CustomVertex.PositionNormalColored(new Vector3(0, 2, 1), new Vector3(1, 0, 1), Color.Red.ToArgb()); 
            vertexes[1] = new CustomVertex.PositionNormalColored(new Vector3(0, -2, 1), new Vector3(-1, 0, 1), Color.Red.ToArgb());
vertexes[2] = new CustomVertex.PositionNormalColored(new Vector3(2, -2, 1), new Vector3(-1, 0, 1), Color.Red.ToArgb());
vertexes[3] = new CustomVertex.PositionNormalColored(new Vector3(2, -2, 1), new Vector3(-1, 0, 1), Color.Red.ToArgb()); 
            vertexes[4] = new CustomVertex.PositionNormalColored(new Vector3(2, 2, 1), new Vector3(-1, 0, 1), Color.Red.ToArgb()); 
            vertexes[5] = new CustomVertex.PositionNormalColored(new Vector3(0, 2, 1), new Vector3(1, 0, 1), Color.Red.ToArgb());
device.Clear(ClearFlags.Target, Color.Cyan, 1.0f, 0); 
            device.BeginScene(); 
            device.VertexFormat = CustomVertex.PositionNormalColored.Format; 
            device.DrawUserPrimitives(PrimitiveType.TriangleList, vertexes.Length / 3, vertexes); //in the above line(vertexes.Length=6, so 6/3=2) hence, 1 for single triangle & 2 for double triangle 
            device.EndScene(); 
            device.Present(); 
        }
    }
}
