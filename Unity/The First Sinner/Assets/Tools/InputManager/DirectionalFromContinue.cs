using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace InputManager
{

    public class DirectionalFromContinue : AbstractDirectionalInput
    {

        public static DirectionalFromContinue WASD
        {
            get
            {
                DirectionalFromContinue dir = new DirectionalFromContinue();
                dir.AddUp(new ContinueKeyboard(KeyCode.W));                
                dir.AddRight(new ContinueKeyboard(KeyCode.D));                
                dir.AddDown(new ContinueKeyboard(KeyCode.S));                
                dir.AddLeft(new ContinueKeyboard(KeyCode.A));                
                return dir;
            }
        }

        public static DirectionalFromContinue ArrowsKeyboard
        {
            get
            {
                DirectionalFromContinue dir = new DirectionalFromContinue();
                dir.AddUp(new ContinueKeyboard(KeyCode.UpArrow));                
                dir.AddRight(new ContinueKeyboard(KeyCode.RightArrow));                
                dir.AddDown(new ContinueKeyboard(KeyCode.DownArrow));                
                dir.AddLeft(new ContinueKeyboard(KeyCode.LeftArrow));                
                return dir;
            }
        }

        public static DirectionalFromContinue ArrowsAndWASD => Union(ArrowsKeyboard, WASD);       


        internal HashSet<AbstractContinueInput> W { get; private set ;}
        internal HashSet<AbstractContinueInput> A { get; private set ;}
        internal HashSet<AbstractContinueInput> S { get; private set ;}
        internal HashSet<AbstractContinueInput> D { get; private set ;}
                                                
        public void AddUp(AbstractContinueInput inp) => W.Add(inp);
        public void AddDown(AbstractContinueInput inp) => S.Add(inp);
        public void AddLeft(AbstractContinueInput inp) => A.Add(inp);
        public void AddRight(AbstractContinueInput inp) => D.Add(inp);

        public static DirectionalFromContinue Union(DirectionalFromContinue a , DirectionalFromContinue b)
        {
            DirectionalFromContinue dir = new DirectionalFromContinue();
            dir.W = new HashSet<AbstractContinueInput>(a.W.Concat(b.W));
            dir.A = new HashSet<AbstractContinueInput>(a.A.Concat(b.A));
            dir.S = new HashSet<AbstractContinueInput>(a.S.Concat(b.S));
            dir.D = new HashSet<AbstractContinueInput>(a.D.Concat(b.D));
            return dir;
        }

        public DirectionalFromContinue()
        {
            W = new HashSet<AbstractContinueInput>();
            A = new HashSet<AbstractContinueInput>();
            D = new HashSet<AbstractContinueInput>();
            S = new HashSet<AbstractContinueInput>();
        }

        public override Vector2 Direction
        {
            get
            {
                Vector2 v = Vector2.zero;
                v += (W.Any((item) => item.Happens)) ? Vector2.up : Vector2.zero;
                v += (A.Any((item) => item.Happens)) ? Vector2.left : Vector2.zero;
                v += (S.Any((item) => item.Happens)) ? Vector2.down : Vector2.zero;
                v += (D.Any((item) => item.Happens)) ? Vector2.right : Vector2.zero;
                return v.normalized;
            }
        }
        public DirectionalFromContinue InvertY
        {
            get
            {
                DirectionalFromContinue dir = new DirectionalFromContinue();
                W = new HashSet<AbstractContinueInput>(S);
                A = new HashSet<AbstractContinueInput>(A);
                S = new HashSet<AbstractContinueInput>(W);
                D = new HashSet<AbstractContinueInput>(D);
                return dir;
            }
        }
        public DirectionalFromContinue InvertX
        {
            get
            {
                DirectionalFromContinue dir = new DirectionalFromContinue();
                S = new HashSet<AbstractContinueInput>(S);
                D = new HashSet<AbstractContinueInput>(A);
                W = new HashSet<AbstractContinueInput>(W);
                A = new HashSet<AbstractContinueInput>(D);
            
                return dir;
            }
        }
    }

}
