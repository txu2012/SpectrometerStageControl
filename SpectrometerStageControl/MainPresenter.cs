using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrometerStageControl
{
    public struct MotorSettings
    {
        public string StageType;
        public decimal MaxAccelerationMms2;
        public decimal MaxVelocityMms;
        public decimal MinVelocityMms;
        public decimal MaxTravelMm;
        public decimal MinDistance;

        public decimal HomingVelocityMms;
        public decimal HomingOffsetMm;
    }

    public interface IMainView
    {
        void UpdateScreen();
    }

    public interface IMainPresenter
    {

    }

    public class MainPresenter : IMainPresenter
    {
        public MainPresenter() { }
    }
}
