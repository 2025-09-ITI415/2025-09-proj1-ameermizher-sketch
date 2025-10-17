using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(LineRenderer))]
public class Basketball : MonoBehaviour{
    static List <Basketball> PROJ_LINES = new List<Basketball>();
    private const float DIM_MULT = 0.75f;

    private LineRenderer _line;
    private bool _drawing = true;
    public Basketball _projectile;
    // Start is called before the first frame update
    void Start(){
        _line = GetComponent<LineRenderer>();
        _line.positionCount = 1;
        _line.SetPosition( 0, transform.position );
        _projectile = GetComponentInParent<Basketball>();
        ADD_LINE( this );
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (_drawing) {
            _line.positionCount++;
            _line.SetPosition(_line.positionCount -1, transform.position);

            if(_projectile != null){
                if (_projectile){
                    _drawing = false;
                    _projectile = null;
                }
            }
        }
    }
    private void OnDestroy(){
        PROJ_LINES.Remove( this );
    }

    static void ADD_LINE( Basketball newLine){
        Color col;
        foreach (Basketball pl in PROJ_LINES){
            col = pl._line.startColor;
            col = col*DIM_MULT;
            pl._line.startColor = pl._line.endColor = col;
        }
        PROJ_LINES.Add( newLine);
    }
}
