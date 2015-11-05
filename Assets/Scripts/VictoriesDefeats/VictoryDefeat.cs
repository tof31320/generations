using UnityEngine;
using System.Collections;

public interface VictoryDefeat {

    bool Check();

    void SetEnabled(bool enabled);

    bool Enabled();
}
