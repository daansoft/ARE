using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public abstract class Layer
    {
        public Layer(Guid identificator, int inputLayerCount)
        {
            this.Identificator = identificator;
            this.Layers = new Layer[inputLayerCount];
        }

        public event LayerEventHandler Change;

        public Guid Identificator
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Layer[] Layers
        {
            get;
            set;
        }

        public virtual int Width
        {
            get
            {
                return this.Layers[0].Width;
            }
        }

        public virtual int Height
        {
            get
            {
                return this.Layers[0].Height;
            }
        }

        public virtual IConnectionBuilder GetConnectionBuilder()
        {
            return new LayerConnectionBuilder(this);
        }

        public abstract PixelColor GetPixelColor(int x, int y);

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("Identificator: {0}", this.Identificator);
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("Name: {0}", this.Name ?? String.Empty);
            stringBuilder.AppendLine();

            if (this.Layers.Any() && this.Layers.Length > 0)
            {
                for (int i = 0; i < this.Layers.Length; i++)
                {
                    stringBuilder.AppendFormat("Layer {0} for layer {1}", i + 1, this.Identificator);
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine(this.Layers[i].ToString());
                    stringBuilder.AppendLine();
                }
            }

            return stringBuilder.ToString();
        }

        public virtual void RefreshAfterChangePrevoiusLayer(object sender, EventArgs e)
        {
            Console.WriteLine("Refresh after change: {0}", this.Identificator);
            this.OnChange();
        }

        public virtual void OnChange()
        {
            if (this.Change != null)
            {
                this.Change(this, new EventArgs());
            }
        }
    }
}
