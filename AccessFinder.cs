using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEArts.Etc.CollectionLibrary;
namespace AccessPath
{
    public partial class AccessFinder : Form
    {
        //int k { get; set; }
        //int get_k() { Debuger.Loger.DebugInfo("GetFromMethod"); return k; }
        //void set_k(int x) { Debuger.Loger.DebugInfo("SetFromMethod"); k = x; }
        public AccessFinder()
        {
            InitializeComponent();
            //k = 0;
            //int y = get_k();
            //set_k(1);
            //y = get_k();
            AppDomain.CurrentDomain.UnhandledException += (e, f) =>
            {
                Debuger.Loger.DebugInfo(f);
                Debuger.Loger.DebugInfo(f.ExceptionObject);
            };
            Application.ThreadException += (g, h) =>
            {
                Debuger.Loger.DebugInfo(g);
                Debuger.Loger.DebugInfo(h);
                Debuger.Loger.DebugInfo(h.Exception);
            };
            ConsoleLoger.Instance.RegistLoger();
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!(mbrAllAssemblys.ContainsKey(a.FullName)))
                {
                    mbrAllAssemblys.Add(a.FullName, a);
                }
                if(!(mbrAllFiles.ContainsKey(a.Location)))
                {
                    mbrAllFiles.Add(a.Location, a);
                }
            }
            AppDomain.CurrentDomain.AssemblyLoad += (n, v) =>
            {
                try
                {
                    //Console.WriteLine(n.ToString());
                    Console.WriteLine(v.LoadedAssembly);
                    if (mbrAllAssemblys.ContainsKey(v.LoadedAssembly.FullName))
                    {
                        return;
                    }
                    mbrAllAssemblys.Add(v.LoadedAssembly.FullName,v.LoadedAssembly);
                    //Debuger.Loger.DebugInfo(n);
                    //Debuger.Loger.DebugInfo(v);
                }
                catch { }
            };
            AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
            {
                //Debuger.Loger.DebugInfo(s);
                Debuger.Loger.DebugInfo("e.Name : " + e.Name);
                Debuger.Loger.DebugInfo("e.RequestingAssembly : " + e.RequestingAssembly);
                if (mbrRequestName == e.Name)
                {
                    Debuger.Loger.DebugInfo("Reload assembly : " + e.Name);
                    Assembly asc = Assembly.ReflectionOnlyLoad(e.Name);
                    if (asc == null)
                    {
                        Debuger.Loger.DebugInfo("Load assembly return null");
                    }
                    return asc;
                }
                if (mbrAllAssemblys.ContainsKey(e.Name))
                {
                    return mbrAllAssemblys[e.Name];
                }
                //foreach (var assembly in (s as AppDomain).GetAssemblies())
                //{
                //    if (assembly.FullName == e.Name)
                //    {
                //        Debuger.Loger.DebugInfo("assembly.FullName : " + assembly.FullName);
                //        return assembly;
                //    }
                //}
                mbrRequestName = e.Name;
                Assembly asb = Assembly.LoadFrom(e.Name);
                Debuger.Loger.DebugInfo(asb.Location);
                mbrAllAssemblys.Add(asb.FullName, asb);
                mbrAllFiles.Add(asb.Location, asb);
                return asb;
            };
        }
        private string mbrRequestName;
        Dictionary<string, Assembly> mbrAllAssemblys = new Dictionary<string, Assembly>();
        public bool IsBaseType(Type type)
        {
            return type == typeof(bool) ||
                type == typeof(byte) ||
                type == typeof(Byte) ||
                type == typeof(char) ||
                type == typeof(Char) ||
                type == typeof(decimal) ||
                type == typeof(Decimal) ||
                type == typeof(double) ||
                type == typeof(Double) ||
                type == typeof(float) ||
                type == typeof(int) ||
                type == typeof(Int32) ||
                type == typeof(long) ||
                type == typeof(Int64) ||
                type == typeof(sbyte) ||
                type == typeof(SByte) ||
                type == typeof(short) ||
                type == typeof(Int16) ||
                type == typeof(uint) ||
                type == typeof(UInt32) ||
                type == typeof(ulong) ||
                type == typeof(UInt64) ||
                type == typeof(ushort) ||
                type == typeof(UInt16) ||
                type == typeof(string) ||
                type == typeof(String) ||
                type == typeof(object) ||
                type == typeof(Object) ||
                type == typeof(ObjRef) ||
                type == typeof(MarshalByValueComponent) ||
                type == typeof(MarshalByRefObject) ||
                type == typeof(Type) ||
                type == typeof(IntPtr) ||
                type == typeof(UIntPtr) ||
                type == typeof(PropertyInfo) ||
                type == typeof(MethodInfo) ||
                type == typeof(FieldInfo) ||
                type == typeof(TaskFactory<>) ||
                type == typeof(TaskFactory) ||
                type == typeof(Task<>) ||
                type == typeof(Task) ||
                type == typeof(void) ||
                type.BaseType == typeof(Exception) ||
                type == typeof(Exception) ||
                type == typeof(ParameterInfo) ||
                type == typeof(MemberInfo) ||
                type == typeof(EventInfo) ||
                type == typeof(ConstructorInfo) ||
                type == typeof(TypeInfo) ||
                type == typeof(Boolean);
        }
        private Random r = new Random(1514526353);
        private Tree<TypeElement, TypeElement> mbrTypeTree;
        private Dictionary<Type, string> mbrAllTypes = new Dictionary<Type, string>();
        private Dictionary<string, Assembly> mbrAllFiles = new Dictionary<string, Assembly>();
        private List<TypeElement> mbrAllelement = new List<TypeElement>();
        public Color GetRand()
        {
            return Color.FromArgb(r.Next() % 255, r.Next() % 255, r.Next() % 255, r.Next() % 255);
        }
        public Color GetRand(Color bc)
        {
            return Color.FromArgb(bc.A + (r.Next() % 2 == 0 ? 1 : -1) * r.Next() % 255, bc.R + (r.Next() % 2 == 0 ? 1 : -1) * r.Next() % 255, bc.G + (r.Next() % 2 == 0 ? 1 : -1) * r.Next() % 255, bc.B + (r.Next() % 2 == 0 ? 1 : -1) * r.Next() % 255);
        }
        public Color Invert(Color bc)
        {
            return Color.FromArgb(255 - bc.A, 255 - bc.R, 255 - bc.G, 255 - bc.B);
        }
        private Assembly ass;
        private void mbrBrowser_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "*.dll|*.dll|*.exe|*.exe|*.*|*.*";
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ass = Assembly.LoadFrom(of.FileName);
                foreach (Type t in (from p in ass.GetTypes() orderby p.Namespace, p.Name select p))
                {
                    mbrType.Items.Add(t.Namespace + " | " + t.ToString());
                }
            }
        }
        private void mbrType_TextChanged(object sender, EventArgs e)
        {
        }

        private void mbrType_SelectedValueChanged(object sender, EventArgs e)
        {
            Debuger.Loger.DebugInfo("mbrType_SelectedValueChanged");
            Debuger.Loger.DebugInfo(mbrType.SelectedValue);
            Type t = ass.GetType(mbrType.Text.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            if (t != null)
            {
                TypeElement ex = new TypeElement() { Text = t.Name, TypeName = t.Name, Type = t };
                TypeElementNode nd = new TypeElementNode(ex);
                if (!(mbrAllTypes.ContainsKey(t)))
                {
                    mbrAllTypes.Add(t, "^");
                }
                ex.Node = nd;
                mbrTypeTree = new Tree<TypeElement, TypeElement>(nd);
                TreeNode n = mbrDraw.Nodes.Add(string.Format("[{0}:{1}]", ex.TypeName, ex.Text));
                ex.TreeNode = n;
                ex.Name = t.Name;
                mbrAllelement.Add(ex);
                buildTree(t, n, mbrTypeTree.Root, "^");
                mbrDraw.ExpandAll();
                //drawTree();
            }
            mbrDraw.ExpandAll();
        }
        private void drawTree()
        {
            if (mbrTypeTree.Root == null)
            {
                return;
            }
            Graphics g = mbrDraw.CreateGraphics();
            Color b = GetRand(), f = Invert(b);
            GraphicsPath p = new GraphicsPath();
            Rectangle r = mbrDraw.ClientRectangle;
            drawTreeNode(mbrTypeTree.Root, g, b, f, r);
            //g.DrawPath(new Pen(new SolidBrush(b)),new GraphicsPath)
        }
        private void drawTreeNode(INode<TypeElement, TypeElement> node, Graphics g, Color b, Color f, Rectangle r)
        {
            GraphicsPath p = new GraphicsPath();
        }
        private void buildTree(Type t, TreeNode d, INode<TypeElement, TypeElement> node, string part)
        {
            //if (IsBaseType(t) || ((d.Parent != null && d.Parent.Tag != null) && t == (d.Parent.Tag as TypeElement).Type))
            //{
            //    return;
            //}
            int i = 0;
            string pstr = "";
            foreach (PropertyInfo p in from g in t.GetProperties() orderby g.Name select g)
            {
                i++;
                TypeElement e = new TypeElement() { ElementType = TypeElementType.Property, Text = p.ToString().Substring(p.ToString().IndexOf(p.PropertyType.Name.Substring(0,p.PropertyType.Name.Length - 1))), Count = 1, TypeName = p.PropertyType.Name, Type = p.PropertyType };
                INode<TypeElement, TypeElement> n = node.AddChild(e);
                e.Node = n;
                TreeNode x = d.Nodes.Add(string.Format("P  [{0}:{1}]{2}", e.TypeName, e.Text, (mbrAllTypes.ContainsKey(p.PropertyType) ? "   " + mbrAllTypes[p.PropertyType] : "")));
                x.Tag = e;
                e.TreeNode = x;
                e.Name = p.Name;
                mbrAllelement.Add(e);
                if (!IsBaseType(p.PropertyType) && !(mbrAllTypes.ContainsKey(p.PropertyType)))
                {
                    mbrAllTypes.Add(p.PropertyType, string.Format("{0}.{1}", part, p.Name));
                    buildTree(p.PropertyType, x, n, p.Name);
                }
                pstr = string.Format("{0},{1}", pstr, p.Name);
            }
            Debuger.Loger.DebugInfo(DebugType.Error, pstr);
            foreach (MethodInfo m in from e in t.GetMethods() orderby e.Name select e)
            {
                //o.Equals; o.GetHashCode; o.GetType; o.ToString;
                if (m.Name.StartsWith("get_") || m.Name.StartsWith("set_") || m.Name == "Equals" || m.Name == "GetHashCode" || m.Name == "GetType" || m.Name == "ToString")
                {
                    continue;
                }
                i++;
                TypeElement e = new TypeElement() { Text = m.ToString().Substring(m.ToString().IndexOf(m.ReturnType.Name.Substring(0, m.ReturnType.Name.Length - 1))), TypeName = m.ReturnType.Name, Count = 1, ElementType = TypeElementType.Method, Type = m.ReturnType };
                INode<TypeElement, TypeElement> n = node.AddChild(e);
                e.Node = n;
                TreeNode x = d.Nodes.Add(string.Format("M  [{0}:{1}]{2}", e.TypeName, e.Text, (mbrAllTypes.ContainsKey(m.ReturnType) ? "   " + mbrAllTypes[m.ReturnType] : "")));
                e.TreeNode = x;
                e.Name = m.Name;
                mbrAllelement.Add(e);
                x.Tag = e;
                if (!IsBaseType(m.ReturnType) && !(mbrAllTypes.ContainsKey(m.ReturnType)))
                {
                    mbrAllTypes.Add(m.ReturnType, string.Format("{0}.{1}", part, m.ReturnType));
                    buildTree(m.ReturnType, x, n, m.Name);
                }
            }
            foreach (FieldInfo f in from l in t.GetFields() orderby l.Name select l)
            {
                i++;
                TypeElement e = new TypeElement() { Count = 1, TypeName = f.FieldType.Name, Text = f.ToString().Substring(f.ToString().IndexOf(f.FieldType.Name.Substring(0, f.FieldType.Name.Length - 1))), ElementType = TypeElementType.Field, Type = f.FieldType };
                INode<TypeElement, TypeElement> n = node.AddChild(e);
                e.Node = n;
                TreeNode x = d.Nodes.Add(string.Format("F  [{0}:{1}]{2}", e.TypeName, e.Text, (mbrAllTypes.ContainsKey(f.FieldType) ? "   " + mbrAllTypes[f.FieldType] : "")));
                e.TreeNode = x;
                e.Name = f.Name;
                mbrAllelement.Add(e);
                x.Tag = e;
                if (!IsBaseType(f.FieldType) && !(mbrAllTypes.ContainsKey(f.FieldType)))
                {
                    mbrAllTypes.Add(f.FieldType, string.Format("{0}.{1}", part, f.FieldType));
                    buildTree(f.FieldType, x, n, f.Name);
                }
            }
            node.value.Count = i;
        }

        private string createProperty(PropertyInfo p)
        {
            string s = p.Name + (p.GetMethod.GetParameters().Length == 0 ? "" : "[" + p.GetMethod.GetParameters()[0].ParameterType.Name + " " + p.GetMethod.GetParameters()[0].Name + "]");
            return s;
        }
        private string createMethodNode(MethodInfo m)
        {
            string s = m.Name + "(";
            foreach (ParameterInfo p in m.GetParameters())
            {
                s = string.Format("{0}{1}{2}", s, (s.EndsWith("(") ? "" : ", "), p.ParameterType.Name);
            }
            s = s + ")";
            return s;
        }
        private void mbrType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ass == null)
            {
                return;
            }
            mbrType.Items.Clear();
            foreach (Type t in (from p in ass.GetTypes() where p.Name.StartsWith(mbrType.Text) || p.Name.Contains(mbrType.Text) select p))
            {
                mbrType.Items.Add(t);
            }
        }

        private void mbrDraw_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //if (e.Node.Nodes.Count == 0)
            //{
            //    buildTree((e.Node.Tag as TypeElement).Type, e.Node, (e.Node.Tag as TypeElement).Node);
            //}
        }

        private void mbrDraw_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //e.Node.ExpandAll();
            //if (e.Node.Nodes.Count == 0 && (e.Node.Tag as TypeElement).Type != (e.Node.Parent.Tag as TypeElement).Type)
            //{
            //    buildTree((e.Node.Tag as TypeElement).Type, e.Node, (e.Node.Tag as TypeElement).Node);
            //}
        }
        private void expandAll()
        {
            resetTreeColor();
            if (mbrDraw.SelectedNode != null)
            {
                mbrDraw.SelectedNode.ExpandAll();
            }
            else
            {
                mbrDraw.ExpandAll();
            }
        }
        private void closepandAll()
        {
            resetTreeColor();
            if (mbrDraw.SelectedNode != null)
            {
                mbrDraw.SelectedNode.Collapse();
            }
            else
            {
                mbrDraw.CollapseAll();
            }
        }

        private void mbrExpand_DoubleClick(object sender, EventArgs e)
        {
            expandAll();
        }

        private void mbrClosepand_DoubleClick(object sender, EventArgs e)
        {
            closepandAll();
        }

        private void mbrFinder_TextChanged(object sender, EventArgs e)
        {
            DateTime ts = DateTime.Now;
            if (mbrFinder.Text.Length <= 3)
            {
                return;
            }
            mbrDraw.CollapseAll();
            resetTreeColor();
            int i = 0;
            foreach (TypeElement t in (from l in mbrAllelement where l.Type.Name.Contains(mbrFinder.Text) select l))
            {
                i++;
                TreeNode n = t.TreeNode;
                while (n.Parent != null)
                {
                    if (n.Parent.IsExpanded)
                    {
                        break;
                    }
                    n = n.Parent;
                    n.Expand();
                }
                t.TreeNode.BackColor = Color.DimGray;
                Debuger.Loger.DebugInfo(t.Node);
            }
            DateTime te = DateTime.Now;
            this.Text = "Find result of *" + mbrFinder.Text + "* with " + i.ToString() + " returns used " + (te - ts).TotalMilliseconds + " Milliseconds";
        }
        private void resetTreeColor()
        {
            foreach (TypeElement t in mbrAllelement)
            {
                t.TreeNode.BackColor = mbrDraw.BackColor;
            }
        }

        private void mbrCopy_DoubleClick(object sender, EventArgs e)
        {
            if (mbrDraw.SelectedNode != null)
            {
                string s = "";
                TreeNode n = mbrDraw.SelectedNode;
                while (n.Parent != null)
                {
                    s = (n.Tag as TypeElement).Name + "." + s;
                    n = n.Parent;
                }
                Clipboard.SetText(s);
            }
        }
    }
    public enum TypeElementType { Property, Method, Field }
    public class TypeElement : IItem
    {
        public Type Type { get; set; }
        public INode<TypeElement, TypeElement> Node { get; set; }
        public TypeElementType ElementType { get; set; }
        public string TypeName { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public TreeNode TreeNode { get; set; }
    }
    public class TypeElementNode:NodeBase<TypeElement,TypeElement>
    {
        public TypeElementNode(TypeElement e) : base(e) { }
        public override INode<TypeElement, TypeElement> Create(IItem i)
        {
            return new TypeElementNode(i as TypeElement);
        }
    }
}
