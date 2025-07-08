using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;



public class UsuarioConfiguracion
{
    public string user_id;
    public string nombre;
    public Juegos juegos;

    public class Juegos
    {
        public FruitNinjaVR fruit_ninja_vr;
        public ConectarCables conectar_cables;
        public CookieTwistVR cookie_twist_vr;
        public AirRingVR air_ring_vr;
    }

    public class FruitNinjaVR
    {
        public int tamaño_fruta;
        public int tamaño_cuchillo;
        public int frecuencia_aparicion;
        public float tiempo_entre_frutas;
        public float velocidad_fruta;
        public int duracion_sesion_segundos;
    }

    public class ConectarCables
    {
        public int numero_repeticiones;
        public int numero_series;
        public float tiempo_limite_por_conexion;
        public int tiempo_total_segundos;
    }

    public class CookieTwistVR
    {
        public int separacion_carriles;
        public int frecuencia_galletas;
        public int aleatoriedad_lateral;
        public int duracion_sesion_segundos;
    }

    public class AirRingVR
    {
        public int angulo_rotacion_minimo;
        public int angulo_rotacion_maximo;
        public int frecuencia_anillos;
        public string mano_objetivo;
    }
}

public class UsuarioProgreso
{
    public string user_id;
    public string nombre;
    public int edad;
    public string fecha_inicio;
    public Juegos juegos;
    public ProgresoGeneral progreso_general;

    public class Juegos
    {
        public FruitNinjaVR fruit_ninja_vr;
        public ConectarCables conectar_cables;
        public CookieTwistVR cookie_twist_vr;
        public AirRingVR air_ring_vr;
    }

    public class FruitNinjaVR
    {
        public List<FruitNinjaSesion> sesiones;
    }

    public class FruitNinjaSesion
    {
        public string fecha;
        public int frutas_cortadas;
        public int errores;
        public int tiempo_total;
        public float tiempo_promedio_reaccion;
    }

    public class ConectarCables
    {
        public List<ConectarCablesSesion> sesiones;
    }

    public class ConectarCablesSesion
    {
        public string fecha;
        public int cables_conectados;
        public int errores;
        public int tiempo_total;
        public float tiempo_promedio_conexion;
    }

    public class CookieTwistVR
    {
        public List<CookieTwistSesion> sesiones;
    }

    public class CookieTwistSesion
    {
        public string fecha;
        public int galletas_atrapadas;
        public int inclinaciones_correctas;
        public int tiempo_total;
    }

    public class AirRingVR
    {
        public List<AirRingSesion> sesiones;
    }

    public class AirRingSesion
    {
        public string fecha;
        public int anillos_pasados;
        public int errores;
        public int angulo_maximo;
        public int tiempo_total;
    }

    public class ProgresoGeneral
    {
        public int sesiones_completadas;
        public string ultimo_acceso;
    }
}


public static class JsonConverter
{
    // Convierte un objeto UsuarioProgreso a JSON
    public static string ConvertToJson(UsuarioProgreso data, bool prettyPrint = true)
    {
        return JsonUtility.ToJson(data, prettyPrint);
    }

    // Convierte un string JSON a un objeto UsuarioProgreso
    public static UsuarioProgreso ConvertFromJson(string json)
    {
        return JsonUtility.FromJson<UsuarioProgreso>(json);
    }

    // Guarda el JSON en un archivo (por ejemplo, en Application.persistentDataPath)
    public static void SaveToFile(UsuarioProgreso data, string fileName)
    {
        string json = ConvertToJson(data);
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, json);
        Debug.Log($"JSON guardado en: {path}");
    }

    // Carga JSON desde un archivo y lo convierte a UsuarioProgreso
    public static UsuarioProgreso LoadFromFile(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return ConvertFromJson(json);
        }
        else
        {
            Debug.LogWarning($"Archivo no encontrado en: {path}");
            return null;
        }
    }
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    


    // Convierte un objeto UsuarioProgreso a JSON
    public static string ConvertToJson(UsuarioConfiguracion data, bool prettyPrint = true)
    {
        return JsonUtility.ToJson(data, prettyPrint);
    }

    // Convierte un string JSON a un objeto UsuarioProgreso
    public static UsuarioProgreso ConvertFromJson(string json)
    {
        return JsonUtility.FromJson<UsuarioProgreso>(json);
    }

    // Guarda el JSON en un archivo (por ejemplo, en Application.persistentDataPath)
    public static void SaveToFile(UsuarioConfiguracion data, string fileName)
    {
        string json = ConvertToJson(data);
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, json);
        Debug.Log($"JSON guardado en: {path}");
    }

    // Carga JSON desde un archivo y lo convierte a UsuarioProgreso
    public static UsuarioProgreso LoadFromFile(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return ConvertFromJson(json);
        }
        else
        {
            Debug.LogWarning($"Archivo no encontrado en: {path}");
            return null;
        }
    }


    /*
    public User currentUser;
    public List<User> users = new List<User>();


    public void LoadUsers()
    {
        string json = File.ReadAllText(Application.streamingAssetsPath + "/Data/User_Parameters.json");

        users = JsonConvert.DeserializeObject<List<User>>(json);
        Debug.Log(users);
        if (users == null)
        {
            users = new List<User>();
            users.Add(new User());
        }
        currentUser = users[0];
    }
    public void SaveUsers()
    {

    }
    public void SelectUser(string name)
    {

        foreach (var user in users)
        {
            if (user.username == name)
            {
                currentUser = user;
            }
        }
        if (currentUser == null)
        {
            currentUser = new User();
        }
    }

    public void SaveUser()
    {
        foreach (var user in users)
        {
            if (user.username == currentUser.username)
            {
                users[users.IndexOf(user)] = currentUser;
                break;
            }
        }
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(Application.streamingAssetsPath + "/Data/User_Parameters.json", json);

    }
    */

    public void ChangeValue(string valueName, float value)
    { }



    public UsuarioConfiguracion configuracionActual;
    public UsuarioProgreso progresoActual;

    // Cargar datos iniciales (opcional)
    void Start()
    {
        // Puedes cargar desde archivo aquí si lo deseas
        configuracionActual = new UsuarioConfiguracion();
        progresoActual = new UsuarioProgreso();
    }

    // Ejemplo: actualizar nombre del usuario
    public void SetNombreUsuario(string nuevoNombre)
    {
        if (configuracionActual != null)
        {
            configuracionActual.nombre = nuevoNombre;
        }

        if (progresoActual != null)
        {
            progresoActual.nombre = nuevoNombre;
        }
    }

    // Actualiza parámetros del juego Fruit Ninja
    public void SaveFruitNinja(int fruta, int cuchillo, int frecuencia, int velocidad)
    {
        SetTamañoFruta(fruta);
        SetTamañoCuchillo(cuchillo);
        SetFrecuenciaAparicion(frecuencia);
        SetVelocidadFruta(velocidad);

    }
    public void SetTamañoFruta(int valor)
    {
        if (configuracionActual.juegos.fruit_ninja_vr == null)
            configuracionActual.juegos.fruit_ninja_vr = new UsuarioConfiguracion.FruitNinjaVR();

        configuracionActual.juegos.fruit_ninja_vr.tamaño_fruta = valor;
    }

    public void SetTamañoCuchillo(int valor)
    {
        if (configuracionActual.juegos.fruit_ninja_vr == null)
            configuracionActual.juegos.fruit_ninja_vr = new UsuarioConfiguracion.FruitNinjaVR();
        configuracionActual.juegos.fruit_ninja_vr.tamaño_cuchillo = valor;
    }

    public void SetFrecuenciaAparicion(int valor)
    {
        if (configuracionActual.juegos.fruit_ninja_vr == null)
            configuracionActual.juegos.fruit_ninja_vr = new UsuarioConfiguracion.FruitNinjaVR();
        configuracionActual.juegos.fruit_ninja_vr.frecuencia_aparicion = valor;
    }

    public void SetVelocidadFruta(float valor)
    {
        if (configuracionActual.juegos.fruit_ninja_vr == null)
            configuracionActual.juegos.fruit_ninja_vr = new UsuarioConfiguracion.FruitNinjaVR();

        configuracionActual.juegos.fruit_ninja_vr.velocidad_fruta = valor;
    }


    // Ejemplo genérico: actualizar lateralidad del juego Cookie


    public void SetLateralidad(int valor)
    {
        if (configuracionActual.juegos.cookie_twist_vr == null)
            configuracionActual.juegos.cookie_twist_vr = new UsuarioConfiguracion.CookieTwistVR();

        configuracionActual.juegos.cookie_twist_vr.aleatoriedad_lateral = valor;
    }
    //Actualiza el número de repeticiones en el juego Conectar Cables

    public void SaveCable(int repeticiones, int series, float tiempoLimite)
    {
        SetNumeroRepeticiones(repeticiones);
        SetNumeroSeries(series);
        SetTiempoLimitePorConexion(tiempoLimite);
    }

    public void SetNumeroRepeticiones(int valor)
    {
        if (configuracionActual.juegos.conectar_cables == null)
            configuracionActual.juegos.conectar_cables = new UsuarioConfiguracion.ConectarCables();

        configuracionActual.juegos.conectar_cables.numero_repeticiones = valor;
    }

    public void SetNumeroSeries(int valor)
    {
        if (configuracionActual.juegos.conectar_cables == null)
            configuracionActual.juegos.conectar_cables = new UsuarioConfiguracion.ConectarCables();

        configuracionActual.juegos.conectar_cables.numero_series = valor;
    }

    public void SetTiempoLimitePorConexion(float valor)
    {
        if (configuracionActual.juegos.conectar_cables == null)
            configuracionActual.juegos.conectar_cables = new UsuarioConfiguracion.ConectarCables();

        configuracionActual.juegos.conectar_cables.tiempo_limite_por_conexion = valor;
    }

    public void SaveCookietwist(int separacion, int frecuencia)
    {
        SetSeparacionCarriles(separacion);
        SetFrecuenciaGalletas(frecuencia);
    }

    public void SetSeparacionCarriles(int valor)
    {
        if (configuracionActual.juegos.cookie_twist_vr == null)
            configuracionActual.juegos.cookie_twist_vr = new UsuarioConfiguracion.CookieTwistVR();

        configuracionActual.juegos.cookie_twist_vr.separacion_carriles = valor;
    }

    public void SetFrecuenciaGalletas(int valor)
    {
        if (configuracionActual.juegos.cookie_twist_vr == null)
            configuracionActual.juegos.cookie_twist_vr = new UsuarioConfiguracion.CookieTwistVR();

        configuracionActual.juegos.cookie_twist_vr.frecuencia_galletas = valor;
    }

    public void SaveAirRing(int anguloMinimo, int anguloMaximo, int frecuencia, string manoObjetivo)
    {
        SetAnguloRotacionMinimo(anguloMinimo);
        SetAnguloRotacionMaximo(anguloMaximo);
        SetFrecuenciaAnillos(frecuencia);
        SetManoObjetivo(manoObjetivo);
    }
    public void SetAnguloRotacionMinimo(int valor)
    {
        if (configuracionActual.juegos.air_ring_vr == null)
            configuracionActual.juegos.air_ring_vr = new UsuarioConfiguracion.AirRingVR();

        configuracionActual.juegos.air_ring_vr.angulo_rotacion_minimo = valor;
    }
    public void SetFrecuenciaAnillos(int valor)
    {
        if (configuracionActual.juegos.air_ring_vr == null)
            configuracionActual.juegos.air_ring_vr = new UsuarioConfiguracion.AirRingVR();
        configuracionActual.juegos.air_ring_vr.frecuencia_anillos = valor;
    }
    public void SetAnguloRotacionMaximo(int valor)
    {
        if (configuracionActual.juegos.air_ring_vr == null)
            configuracionActual.juegos.air_ring_vr = new UsuarioConfiguracion.AirRingVR();

        configuracionActual.juegos.air_ring_vr.angulo_rotacion_maximo = valor;
    }

    public void SetManoObjetivo(string mano)
    {
        if (configuracionActual.juegos.air_ring_vr == null)
            configuracionActual.juegos.air_ring_vr = new UsuarioConfiguracion.AirRingVR();

        configuracionActual.juegos.air_ring_vr.mano_objetivo = mano;
    }





    public void RegistrarSesionFruitNinja(string fecha, int frutas, int errores, int tiempo, float reaccion)
    {
        if (progresoActual.juegos.fruit_ninja_vr == null)
            progresoActual.juegos.fruit_ninja_vr = new UsuarioProgreso.FruitNinjaVR();

        var sesion = new UsuarioProgreso.FruitNinjaSesion
        {
            fecha = fecha,
            frutas_cortadas = frutas,
            errores = errores,
            tiempo_total = tiempo,
            tiempo_promedio_reaccion = reaccion
        };

        progresoActual.juegos.fruit_ninja_vr.sesiones.Add(sesion);
        progresoActual.progreso_general.sesiones_completadas++;
        progresoActual.progreso_general.ultimo_acceso = fecha;
    }

    public void RegistrarSesionConectarCables(string fecha, int cables, int errores, float tiempoConexion, int tiempoTotal)
    {
        if (progresoActual.juegos.conectar_cables == null)
            progresoActual.juegos.conectar_cables = new UsuarioProgreso.ConectarCables();

        var sesion = new UsuarioProgreso.ConectarCablesSesion
        {
            fecha = fecha,
            cables_conectados = cables,
            errores = errores,
            tiempo_promedio_conexion = tiempoConexion,
            tiempo_total = tiempoTotal
        };

        progresoActual.juegos.conectar_cables.sesiones.Add(sesion);
        progresoActual.progreso_general.sesiones_completadas++;
        progresoActual.progreso_general.ultimo_acceso = fecha;
    }

    public void RegistrarSesionCookieTwist(string fecha, int galletas, int inclinaciones, int tiempoTotal)
    {
        if (progresoActual.juegos.cookie_twist_vr == null)
            progresoActual.juegos.cookie_twist_vr = new UsuarioProgreso.CookieTwistVR();

        var sesion = new UsuarioProgreso.CookieTwistSesion
        {
            fecha = fecha,
            galletas_atrapadas = galletas,
            inclinaciones_correctas = inclinaciones,
            tiempo_total = tiempoTotal
        };

        progresoActual.juegos.cookie_twist_vr.sesiones.Add(sesion);
        progresoActual.progreso_general.sesiones_completadas++;
        progresoActual.progreso_general.ultimo_acceso = fecha;
    }

    public void RegistrarSesionAirRing(string fecha, int anillos, int errores, int anguloMax, int tiempoTotal)
    {
        if (progresoActual.juegos.air_ring_vr == null)
            progresoActual.juegos.air_ring_vr = new UsuarioProgreso.AirRingVR();

        var sesion = new UsuarioProgreso.AirRingSesion
        {
            fecha = fecha,
            anillos_pasados = anillos,
            errores = errores,
            angulo_maximo = anguloMax,
            tiempo_total = tiempoTotal
        };

        progresoActual.juegos.air_ring_vr.sesiones.Add(sesion);
        progresoActual.progreso_general.sesiones_completadas++;
        progresoActual.progreso_general.ultimo_acceso = fecha;
    }
}




        /*switch(valueName)
        {
            case "spawnTime":
                currentUser.spawnTime = value;
                break;
            case "fruitSize":
                currentUser.fruitSize = value;
                break;
            case "knifeSize":
                currentUser.knifeSize = value;
                break;
            case "series":
                currentUser.series = value;
                break;
            case "repetitions":
                currentUser.repetitions = value;
                break;
            case "cookieSpeed":
                currentUser.cookieSpeed = value;
                break;
            case "timeLimit":
                currentUser.timeLimit = value;
                break;
            case "spawnDistance":
                currentUser.spawnDistance = value;
                break;
            case "dispertion":
                string aux = "aleatorio";
                switch (value) 
                {
                    case 0:
                        aux = "izquierda";
                        break;
                    case 2:
                        aux = "derecha";
                        break;
                }
                currentUser.dispertion = aux;
                break;
            case "angle":
                currentUser.angle = value;
                break;
        }
        PrintUser();*/
    



//    private void PrintUser()
//    {
//        Debug.Log(currentUser.username);
//        Debug.Log(currentUser.fruitSize);
//        Debug.Log(currentUser.knifeSize);
//        Debug.Log(currentUser.series);
//        Debug.Log(currentUser.repetitions);
//        Debug.Log(currentUser.cookieSpeed);
//        Debug.Log(currentUser.timeLimit);
//        Debug.Log(currentUser.spawnDistance);
//        Debug.Log(currentUser.dispertion);
//        Debug.Log(currentUser.angle);
//    }
