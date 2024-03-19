using UnityEngine;

namespace KartGame.KartSystems {

    public class KeyboardInput1 : BaseInput
    {
        public string TurnInputName = "Hotizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";

        public override InputData GenerateInput() {
            return new InputData
            {
                Accelerate = Input.GetButton(AccelerateButtonName),
                Brake = Input.GetButton(BrakeButtonName),
                TurnInput = Input.GetAxis(TurnInputName)
            };
        }
    }
}
