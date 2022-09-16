/*
Código realizado por: Johann :P

Notas: Código largo y poco entendible
Se debe referenciar todas las variables en Unity (Sliders, Textos, Toggles, etc)

Las variables de opciones como la sensibilidad se exportan con PlayerPrefs, con eso se puede referenciar en otros códigos su valor con PlayerPrefs.GetFloat() //.GetInt // Etc

Básicamente esta vaina controla todo el menú principal con las configuraciones, aún en desarrollo (Errores en las configuraciones de gráficos :/)
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
    [Header("Opciones Volumen")] //Variables volumen
    [SerializeField] private TMP_Text VolumeTextValue = null;
    [SerializeField] private Slider VolumeSlider = null;
    [SerializeField] private float DefVolume = 0.5f;

    [Header("Opciones Gameplay")] //Variables Gameplay (Sensibilidad, invertir)
    [SerializeField] private TMP_Text SensibilidadValue = null;
    [SerializeField] private Slider SensibilidadSlider = null;
    [SerializeField] private int DefSensibilidad = 4;
    public int MainSens = 4;

    [Header("Toggle Invertir")] //Variable invertir eye Y
    [SerializeField] private Toggle InvertYToggle = null;

    [Header("Opciones Graficas")] // Variables gráficas (Brillo, Calidad, Pantalla completa)
    [SerializeField] private Slider BrilloSlider = null;
    [SerializeField] private TMP_Text BrilloTextValue = null;
    private float DefBrillo = 1; 

    [Space(10)]
    [SerializeField] private TMP_Dropdown CalidadDrop;
    [SerializeField] private Toggle FullScreenToggle;

    [Header("Resolución")] //Variables resolución

    public TMP_Dropdown ResDropDown;
    private Resolution[] resolutions;

    //Retener valores actuales

    private int _CalidadActual;
    private bool _isFullScreen;
    private float _BrilloActual;

    [Header("Confirmación")] //Imagen de carga inferior
    [SerializeField] private GameObject confirmationPrompt = null;


    [Header("CargaDeNiveles")] //Variables de escenas
    public string NuevoNivel;
    public string NivelACargar;
    [SerializeField] private GameObject NoSavedGame = null;
    [SerializeField] private GameObject MainMenu = null;
    [SerializeField] private GameObject LoadGame = null;


    private void Start() {                                              //Funcion Start(), usada en este caso para la resolución (Dolor de cabeza)
        resolutions = Screen.resolutions;
        ResDropDown.ClearOptions();

        List<string> Options = new List<string>(); //Lista de resoluciones
        int ResActualIndex = 0;

        for(int i=0; i < resolutions.Length; i++){ //Recoger las posibles resoluciones y ponerlas como opción en el DropDown
            string options = resolutions[i].width + " x " + resolutions[i].height;
            Options.Add(options);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height){
                ResActualIndex = i;
            }

        }
        ResDropDown.AddOptions(Options);
        ResDropDown.value = ResActualIndex;
        ResDropDown.RefreshShownValue();
    }

    public void Jugar_Respuesta_Si(){ //Respuesta si, jugar. Carga el siguiente nivel
        SceneManager.LoadScene(NuevoNivel);
    }
    public void Cargar_Respuesta_si(){ //Respuesta si, cargar nivel. Revisa si hay algún nivel guardado en "PlayerPrefs"
        if(PlayerPrefs.HasKey("SavedLevel")){
            NivelACargar = PlayerPrefs.GetString("SavedLevel");
            //Guardar Nivel: PlayerPrefs.SetString("SavedLevel", [NombreDelNivel])
            SceneManager.LoadScene(NivelACargar);
        }
        else{ //Volver al menú
            LoadGame.SetActive(false);
            MainMenu.SetActive(false);
            NoSavedGame.SetActive(true);
        }
    }

    public void BotonSalir(){
        Application.Quit(); //Cerrar juego
    }

//Sonido
    public void ConfVolumen(float volumen){ //Configurar volúmen
        AudioListener.volume = volumen;
        VolumeTextValue.text = volumen.ToString("0.0");
    }

    public void AplicarVolumen(){ //Aplicar cambios
        PlayerPrefs.SetFloat("VolumenMast", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

//Gameplay

    public void ConfSens(float sensibilidad){ //Configurar sensibilidad                             VARIABLES A EXPORTAR PARA EL MANEJO DE LA SENSIBILIDAD DEL JUEGO
        MainSens = Mathf.RoundToInt(sensibilidad);
        SensibilidadValue.text = sensibilidad.ToString("0");
    }

    public void gameplayApply(){ //Aplicar cambios
        if(InvertYToggle.isOn){
            PlayerPrefs.SetInt("InvertY", 1);
        }
        else{
            PlayerPrefs.SetInt("InvertY", 0);
        }
        PlayerPrefs.SetFloat("MasterSens", MainSens);
        StartCoroutine(ConfirmationBox());
    }

//Graficos
    public void ConfBrillo(float Brillo){ //Configurar valores de brillo
        _BrilloActual = Brillo;
        BrilloTextValue.text = Brillo.ToString("0.0");
    }

    public void ConfPantalla(bool FullScreen){ //Configurar valores de pantalla (Fullscreen) bool
        _isFullScreen = FullScreen;
    }

    public void ConfCalidad(int CalidadValor){ // Configurar valor de calidad
        _CalidadActual = CalidadValor;

    }

    public void ConfResolution(int IndexRes){  //Configurar valores de resolución (relacionados en la funcion Start())
        Resolution resolution = resolutions[IndexRes];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void AplGraficos(){ //Aplicar cambios
        PlayerPrefs.SetFloat("MasterBrillo", _BrilloActual);
        PlayerPrefs.SetInt("MasterCalidad", _CalidadActual);
        QualitySettings.SetQualityLevel(_CalidadActual);

        PlayerPrefs.SetInt("MasterPantallaComp", (_isFullScreen ? 1:0)); // "? 1:0" Para crear un valor bool
        Screen.fullScreen = _isFullScreen;

        StartCoroutine(ConfirmationBox()); //Mostrar imagen de carga
    }

    public void ResetDefBoton(string MenuType){ //Boton de resetear valores por defecto dependiendo el menú
        if(MenuType == "Audio"){
            AudioListener.volume = DefVolume;
            VolumeSlider.value = DefVolume;
            VolumeTextValue.text = DefVolume.ToString("0");
            AplicarVolumen();
        }
        if(MenuType == "Gameplay"){
            SensibilidadValue.text = DefSensibilidad.ToString("0");
            SensibilidadSlider.value = DefSensibilidad;
            MainSens = DefSensibilidad;
            InvertYToggle.isOn = false;
            gameplayApply();
        }
        if(MenuType == "Graficos"){
            BrilloSlider.value = DefBrillo;
            BrilloTextValue.text = DefBrillo.ToString("0.0");

            CalidadDrop.value = 1;
            QualitySettings.SetQualityLevel(1);

            FullScreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution ResoActual = Screen.currentResolution;
            Screen.SetResolution(ResoActual.width, ResoActual.height, Screen.fullScreen);

            ResDropDown.value = resolutions.Length;
            AplGraficos();
        }

    }

    public IEnumerator ConfirmationBox(){ //Mostrar imagen de carga cada vez que hay un cambio en configuraciones
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);

    }
}
