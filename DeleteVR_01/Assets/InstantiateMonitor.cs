using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class InstantiateMonitor : MonoBehaviour
{
    public GameObject headerText;
    public GameObject startPoint;

    public GameObject wordDoc;
    public GameObject vinyl;
    public GameObject quadObj;
    public GameObject sphereObj;

    public ArrayList fileList;
    public ArrayList fileObjectList;
    public GameObject[] iconArray;

    public Texture videoIcon;
    public Texture audioIcon;
    public Texture photoIcon;
    public Texture textIcon;

    Text text;
    RawImage img;
    public string path = "";

    // Start is called before the first frame update
    void Start()
    {

        fileList = new ArrayList();
        fileObjectList = new ArrayList();
        iconArray = GameObject.FindGameObjectsWithTag("Icon");

        // Setup Header
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop).ToString();
        text = headerText.GetComponent<Text>();
        text.text = "Current directory is " + path;

        instantiateAndGetCompatibleFiles(path);       


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void instantiateAndGetCompatibleFiles(string path)
    {
        GameObject panel;
        GameObject quad;
        GameObject sphere;
        int ct = 0;
        foreach (string fileName in Directory.GetFiles(path))
        {
            switch (Path.GetExtension(fileName)) {
                case ".txt":
                    fileList.Add(fileName);
                    quad = Instantiate(wordDoc);
                    quad.transform.position = startPoint.transform.position;

                    quad.transform.localScale = new Vector3(.3f, .3f, .3f);
                    fileList.Add(fileName);
                    fileObjectList.Add(quad);
                    panel = iconArray[ct];
                    panel.GetComponent<Image>().enabled = true;
                    text = panel.GetComponentInChildren(typeof(Text)) as Text;
                    text.fontSize = 10;
                    text.text = Path.GetFileName(fileName);
                    img = panel.GetComponentInChildren(typeof(RawImage)) as RawImage;
                    img.enabled = true;
                    img.texture = textIcon;
                    ct++;
                    break;
                case ".mp4":
                    fileList.Add(fileName);
                    sphere = Instantiate(sphereObj);
                    sphere.transform.position = startPoint.transform.position;

                    sphere.transform.localScale = new Vector3(.3f, .3f, .3f); 
                    var videoPlayer = sphere.AddComponent<UnityEngine.Video.VideoPlayer>();
                    videoPlayer.url = fileName;
                    videoPlayer.playOnAwake = false;
                    videoPlayer.isLooping = true;
                    videoPlayer.audioOutputMode = UnityEngine.Video.VideoAudioOutputMode.None;
                    videoPlayer.Play();
                    fileList.Add(fileName);
                    fileObjectList.Add(sphere);
                    panel = iconArray[ct];
                    panel.GetComponent<Image>().enabled = true;
                    text = panel.GetComponentInChildren(typeof(Text)) as Text;
                    text.fontSize = 10;
                    text.text = Path.GetFileName(fileName);
                    img = panel.GetComponentInChildren(typeof(RawImage)) as RawImage;
                    img.enabled = true;
                    img.texture = videoIcon;
                    ct++;
                    break;
                case ".mp3":
                    fileList.Add(fileName);
                    quad = Instantiate(vinyl);
                    quad.transform.position = startPoint.transform.position;


                    fileList.Add(fileName);
                    fileObjectList.Add(quad);
                    panel = iconArray[ct];
                    panel.GetComponent<Image>().enabled = true;
                    text = panel.GetComponentInChildren(typeof(Text)) as Text;
                    text.fontSize = 10;
                    text.text = Path.GetFileName(fileName);
                    img = panel.GetComponentInChildren(typeof(RawImage)) as RawImage;
                    img.enabled = true;
                    img.texture = audioIcon;
                    ct++;
                    break;
                case ".jpg":
                    fileList.Add(fileName);
                    quad = Instantiate(sphereObj);
                    quad.transform.position = startPoint.transform.position;
                    quad.transform.localScale = new Vector3(.3f, .3f, .3f);
                    // Image file exists - load bytes into texture
                    var bytes = System.IO.File.ReadAllBytes(fileName);
                    var tex = new Texture2D(1, 1);
                    tex.LoadImage(bytes);
                    Material picture = new Material(Shader.Find("Standard"));
                    
                    picture.mainTexture = tex;

                    // Apply to Quad
                    MeshRenderer mr = quad.GetComponent<MeshRenderer>();
                    mr.material = picture;
                   
                    fileList.Add(fileName);
                    fileObjectList.Add(quad);
                    panel = iconArray[ct];
                    panel.GetComponent<Image>().enabled = true;
                    text = panel.GetComponentInChildren(typeof(Text)) as Text;
                    text.fontSize = 10;
                    text.text = Path.GetFileName(fileName);
                    img = panel.GetComponentInChildren(typeof(RawImage)) as RawImage;
                    img.enabled = true;
                    img.texture = photoIcon;
                    ct++;
                    break;
            }
            if (ct == 8)
            {
                break;
            }
        }
    
    }
}
