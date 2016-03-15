﻿using UnityEngine;
using System.Collections;

public class ScreenDisplay : ScreenBase 
{
	public override string Name
	{
		get
		{
			return "ScreenDisplay";
		}
	}

	public CanvasGroup group;
	public RectTransform rect;

	public Touchable buttonBack;

	void Awake()
	{
		buttonBack.OnPointerDownEvent += OnBackButton;
	}

	void OnBackButton (Touchable _sender, UnityEngine.EventSystems.PointerEventData _eventData)
	{
		MenuCamera.instance.prepare("Display", "Options");
		ScreenManager.Instance.SetScreen("ScreenOptions");
	}

	public override void OnScreenEnter()
	{
		rect.anchoredPosition3D = new Vector3(-620f, 0f, 0f);
		HOTweenHelper.Fade(group, 0f, 1f, 0.2f, 0f);
		HOTweenHelper.Position(rect, new Vector3(0f, 0f, 0f), 0.2f, 0f, Holoville.HOTween.EaseType.EaseOutCubic);
	}

	public override void OnScreenExit()
	{
	}

	public override IEnumerator OnScreenFadeIn()
	{
		yield break;
	}

	public override IEnumerator OnScreenFadeOut()
	{
		HOTweenHelper.Fade(group, 1f, 0f, 0.2f, 0f);
		HOTweenHelper.Position(rect, new Vector3(-620f, 0f, 0f), 0.2f, 0f, Holoville.HOTween.EaseType.EaseOutCubic);
		yield return new WaitForSeconds(0.1f);
		yield return MenuCamera.instance.flyFromTo("", "");
	}
}
