using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalistaTraectoryPrediction : MonoBehaviour
{
    [SerializeField] private GameObject traectoryPointPref;
    private float g;
    private float v0;
    [SerializeField] private float dt;
    [SerializeField] private int c;
    private List<GameObject> traectoryPoints;
    private Color color;

    public void SetParams(float g, float v0, Color color)
    {
        this.g = g;
        this.v0 = v0;
        this.color = color;
        // foreach (var point in traectoryPoints)
        //     point.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    public void DrawTraectory(Vector3 position)
    {
        position = transform.localPosition - position;
        Vector3 v0 = position * this.v0;
        Vector3 g = transform.InverseTransformDirection(Vector3.down) * this.g;
        for (int i = 0; i < c; i++)
        {
            float t = (i + 1f) * dt;
            traectoryPoints[i].transform.localPosition = v0 * t + g * t * t / 2f;
            traectoryPoints[i].SetActive(traectoryPoints[i].transform.position.z < 0);
            traectoryPoints[i].GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_Color", color);
            traectoryPoints[i].GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
        }
    }
    public void HidePoints()
    {
        foreach (var point in traectoryPoints)
        {
            point.gameObject.SetActive(false);
        }
    }


    private void Awake()
    {
        traectoryPoints = new List<GameObject>();
        for (int i = 0; i < c; i++)
        {
            traectoryPoints.Add(Instantiate(traectoryPointPref, transform));
            traectoryPoints[i].SetActive(false);
        }
    }
}
