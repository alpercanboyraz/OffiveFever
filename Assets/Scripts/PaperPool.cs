using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPool : MonoBehaviour
{
    
    public GameObject prefab;
    private Stack<GameObject> objeHavuzu = new Stack<GameObject>();

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
             StartCoroutine( SurekliObjeOlusturVeYokEt() );
        }
    }
    
    IEnumerator SurekliObjeOlusturVeYokEt()
    {
        int paper_count = 0;
        while( true )
        {
            
            Vector3 konum = new Vector3(8.97f,-19.72f,66.47f);
            
            if(paper_count > 50 ){
                
                konum = new Vector3(8.97f,-19.72f,69f);
            }
            //8.97f,-19.72f,66.47f
            // Havuzdan obje çekip konumunu değiştir
            GameObject obje = HavuzdanObjeCek();
            obje.transform.position = konum;
            paper_count++;
            // 1 saniye bekle
            yield return new WaitForSeconds( 1f );
 
            // Objeyi havuza geri yolla
            HavuzaObjeEkle( obje );
        }
    }

    GameObject HavuzdanObjeCek()
    {
        // Havuzda obje var mı kontrol et
        if( objeHavuzu.Count > 0 )
        {
            // Havuzdaki en son objeyi çek
            GameObject obje = objeHavuzu.Pop();
 
            // Objeyi aktif hale getir
            obje.gameObject.SetActive( true );
 
            // Objeyi döndür
            return obje;
        }
 
        // Havuz boş, mecburen yeni bir obje Instantiate et
        return Instantiate( prefab );
    }

    void HavuzaObjeEkle( GameObject obje )
    {
        // Objeyi inaktif hale getir (böylece obje artık ekrana çizilmeyecek ve objede
        // Update vs. fonksiyonlar varsa, bu fonksiyonlar obje havuzdayken çalıştırılmayacak)
        obje.gameObject.SetActive( false );
 
        // Objeyi havuza ekle
        objeHavuzu.Push( obje );
    }

}
