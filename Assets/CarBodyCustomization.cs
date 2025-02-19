using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBodyCustomization : MonoBehaviour
{
	[System.Serializable]
	public class subClass
	{
		public GameObject[] RL;
		public GameObject[] RR;
		public GameObject[] FL;
		public GameObject[] FR;
	}
	public subClass rimsArray;
	int carIndex;
	public GameObject carBody;
	public Material[] carDecals, carDecals1, carDecals2, carDecals3, carDecals4, carDecals5;
	public Material carBaseMat;
	public void Start()
    {
		carIndex = PlayerPrefs.GetInt("Player", 0);
		setPlayerRim();
		setPlayerDecal();

	}
    void setPlayerRim()
	{
		int currentRim = PlayerPrefs.GetInt("Car" + (carIndex + 1) + "RimSelected");
		for (int i = 0; i < rimsArray.FL.Length; i++)
		{
			rimsArray.FL[i].SetActive(false);
		}
		for (int i = 0; i < rimsArray.FR.Length; i++)
		{
			rimsArray.FR[i].SetActive(false);
		}
		for (int i = 0; i < rimsArray.RL.Length; i++)
		{
			rimsArray.RL[i].SetActive(false);
		}
		for (int i = 0; i < rimsArray.RR.Length; i++)
		{
			rimsArray.RR[i].SetActive(false);
		}
		rimsArray.FL[currentRim].SetActive(true);
		rimsArray.FR[currentRim].SetActive(true);
		rimsArray.RL[currentRim].SetActive(true);
		rimsArray.RR[currentRim].SetActive(true);
	}
	void setPlayerDecal()
	{
		print(PlayerPrefs.GetInt("Car" + (carIndex + 1) + "DecalSelected"));
		if (PlayerPrefs.GetInt("Car" + (carIndex + 1) + "DecalSelected") != -1)
		{
			print(PlayerPrefs.GetInt("Car" + (carIndex + 1) + "DecalSelected"));
			int currentDecal = PlayerPrefs.GetInt("Car" + (carIndex + 1) + "DecalSelected");
			Material[] mat = carBody.GetComponent<MeshRenderer>().materials;
			if (carIndex == 0)
			{
				mat[0] = carDecals[currentDecal];
			}
			else if (carIndex == 1)
            {
                mat[0] = carDecals1[currentDecal];
            }
            else if (carIndex == 2)
            {
                mat[0] = carDecals2[currentDecal];
            }
            else if (carIndex == 3)
            {
                mat[0] = carDecals3[currentDecal];
            }
            else if (carIndex == 4)
            {
                mat[0] = carDecals4[currentDecal];
            }
            else if (carIndex == 5)
            {
                mat[0] = carDecals5[currentDecal];
            }
            carBody.GetComponent<MeshRenderer>().materials = mat;
		}
		else
		{
			Material[] mat = carBody.GetComponent<MeshRenderer>().materials;
			//if (carIndex == 0)
			//{
				mat[0] = carBaseMat;
			//}
			//else
			//{
				//mat[0] = carBaseMat[carIndex];
			//}
			carBody.GetComponent<MeshRenderer>().materials = mat;
		}
	}

}
