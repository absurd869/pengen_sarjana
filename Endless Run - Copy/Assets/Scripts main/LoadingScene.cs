using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingscreen;
    public TMP_Text progressText;
    public TMP_Text quote;
    public Slider sliderLoad;
    public GameObject tabButton;
    
    private string[] quoteText;

    private int sceneID;

    private void Start()
    {
       sceneID = SceneManager.GetActiveScene().buildIndex;

        if(sceneID == 10)
        {
            LoadMenu(0);
        }
      
    }

    public void LoadLevel(int SceneIndex)
    {
        // StartCoroutine(LoadAsynchronously(SceneIndex));
        StartCoroutine(LoadAsynchronously(11));
        PlayerPrefs.SetInt("LevelSekarang", SceneIndex);
    }

    private void LoadMenu(int SceneIndex)
    {
        StartCoroutine(LoadAsynchronously(SceneIndex));
        //PlayerPrefs.SetInt("LevelSekarang", SceneIndex);
    }

    IEnumerator LoadAsynchronously(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        loadingscreen.SetActive(true);
        QuoteText();

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            sliderLoad.value = progress;
            progressText.text = progress * 100f + "%";

            if (operation.progress >= 0.9f)
            {
                tabButton.SetActive(true);

                if (Input.GetMouseButton(0))
                {
                    //yield return new WaitForSeconds(2);
                    operation.allowSceneActivation = true;

                }
                
            }

            yield return null;
        
        }


    }

    public void QuoteText()
    {
        quoteText = new string[17];
        
        quoteText[0] = "Ingatlah Kehidupan Kampus Dengan Terus Mengasah. Jangan Habiskan Waktumu Untuk Berkeluh Kesah \n\n - Najwa Shihab - ";
        quoteText[1] = "Education Is The Most Powerful Weapon Which You Can Use To Change The World \n\n - Nelson Mandela - ";
        quoteText[2] = "Percaya Proses \n\n - Uknown - ";
        quoteText[3] = "Live As If You Were To Die Tomorrow. Learn As If You Were to Live Forever \n\n - Mahatma Gandhi - ";
        quoteText[4] = "Kuliah Enggan D.O Tak Mau";
        quoteText[5] = "Skripsi Itu Dikerjakan Bukan Cuma Dibayangkan \n\n - Dosen Bijak -";
        quoteText[6] = "Kuliah Itu Susah Tapi Lebih Susah Perjuangan Orang Tua Nguliahin Anaknya \n\n - Pinterest -";
        quoteText[7] = "Kalau Impianmu Tak Bisa Membuatmu Takut, Mungkin Karena Impianmu Tak Cukup Besar \n\n - Muhammad Ali -";
        quoteText[8] = "Takut Cuma Ada Di Perasaanmu Saja \n\n - Gubtha Mahendra Putra - \n Dosen Informatika Unmul";
        quoteText[9] = "Lalu Kapan Saya Akan di Wisuda? \n\n - Koboy Kampus -";
        quoteText[10] = "Selesai Skripsi, Langsung Resepsi \n\n - Penerbitbukudeepublish.com -" ;
        quoteText[11] = "Kegagalan Urusan Nanti Yang Terpenting Kita Harus Berani Mencoba \n\n - ig:kerenkata -";
        quoteText[12] = "Ing Ngarso Sung Tulodo, Ing Madyo Mangun Karso, Tut Wuri Handayani \n\n - Ki Hajar Dewantara -";
        quoteText[13] = "Berusahalah Untuk Lulus Karena Kamu Telah Memilih Untuk Kuliah \n\n - ig:mahasiswanews - ";
        quoteText[14] = "Barangsiapa Tidak Mau Merasakan Pahitnya Belajar, Ia Akan Merasakan Hinanya Kebodohan Sepanjang Hidupnya \n\n - Imam Syafi'i -";
        quoteText[15] = "Ketekunan Sangat Penting. Kamu Tidak Boleh Menyerah Kecuali Terpaksa Menyerah \n\n - Elon Musk - ";
        quoteText[16] = "Awal Dari Kebijaksanaan Adalah Dengan Menaklukkan Rasa Takut \n\n - Bertrand Russel - ";



        int rand = Random.Range(0, 16);
        quote.text = quoteText[rand];
        

    }
}
