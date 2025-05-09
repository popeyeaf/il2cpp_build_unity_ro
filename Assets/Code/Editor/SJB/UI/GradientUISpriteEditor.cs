﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using RO;

namespace EditorTool
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(GradientUISprite), true)]
	public class GradientUISpriteEditor :UISpriteInspector
	{
		GradientUISprite _ui;

		public override void OnInspectorGUI ()
		{
			_ui = target as GradientUISprite;
			base.OnInspectorGUI ();
		}

		protected override void DrawCustomProperties ()
		{
			GUILayout.Space (6f);
			
			SerializedProperty sp = NGUIEditorTools.DrawProperty ("Type", serializedObject, "mType", GUILayout.MinWidth (20f));
			
			UISprite.Type type = (UISprite.Type)sp.intValue;
			
			if (type == UISprite.Type.Simple) {
				NGUIEditorTools.DrawProperty ("Flip", serializedObject, "mFlip");
			} else if (type == UISprite.Type.Tiled) {
				NGUIEditorTools.DrawBorderProperty ("Trim", serializedObject, "mBorder");
				NGUIEditorTools.DrawProperty ("Flip", serializedObject, "mFlip");
			} else if (type == UISprite.Type.Sliced) {
				NGUIEditorTools.DrawBorderProperty ("Border", serializedObject, "mBorder");
				NGUIEditorTools.DrawProperty ("Flip", serializedObject, "mFlip");
				
				EditorGUI.BeginDisabledGroup (sp.hasMultipleDifferentValues);
				{
					sp = serializedObject.FindProperty ("centerType");
					bool val = (sp.intValue != (int)UISprite.AdvancedType.Invisible);
					
					if (val != EditorGUILayout.Toggle ("Fill Center", val)) {
						sp.intValue = val ? (int)UISprite.AdvancedType.Invisible : (int)UISprite.AdvancedType.Sliced;
					}
				}
				EditorGUI.EndDisabledGroup ();
			} else if (type == UISprite.Type.Filled) {
				NGUIEditorTools.DrawProperty ("Flip", serializedObject, "mFlip");
				NGUIEditorTools.DrawProperty ("Fill Dir", serializedObject, "mFillDirection", GUILayout.MinWidth (20f));
				GUILayout.BeginHorizontal ();
				GUILayout.Space (4f);
				NGUIEditorTools.DrawProperty ("Fill Amount", serializedObject, "mFillAmount", GUILayout.MinWidth (20f));
				GUILayout.Space (4f);
				GUILayout.EndHorizontal ();
				NGUIEditorTools.DrawProperty ("Invert Fill", serializedObject, "mInvert", GUILayout.MinWidth (20f));
			} else if (type == UISprite.Type.Advanced) {
				NGUIEditorTools.DrawBorderProperty ("Border", serializedObject, "mBorder");
				NGUIEditorTools.DrawProperty ("  Left", serializedObject, "leftType");
				NGUIEditorTools.DrawProperty ("  Right", serializedObject, "rightType");
				NGUIEditorTools.DrawProperty ("  Top", serializedObject, "topType");
				NGUIEditorTools.DrawProperty ("  Bottom", serializedObject, "bottomType");
				NGUIEditorTools.DrawProperty ("  Center", serializedObject, "centerType");
				NGUIEditorTools.DrawProperty ("Flip", serializedObject, "mFlip");
			}

			GUILayout.BeginHorizontal ();
			SerializedProperty gr = NGUIEditorTools.DrawProperty ("Gradient", serializedObject, "isGradient",
			                                                     GUILayout.Width (95f));
			EditorGUI.BeginDisabledGroup (!gr.hasMultipleDifferentValues && !gr.boolValue);
			{
				NGUIEditorTools.SetLabelWidth (30f);
				NGUIEditorTools.DrawProperty ("Dir", serializedObject, "dir", GUILayout.MinWidth (40f));
				GUILayout.EndHorizontal ();

				GUILayout.BeginHorizontal ();
				NGUIEditorTools.SetLabelWidth (50f);
				GUILayout.Space (79f);
				NGUIEditorTools.DrawProperty (_ui.dir == GradientUISprite.GradientDirection.Vertical ? "Top" : "Left", serializedObject, "mgradientTop", GUILayout.MinWidth (40f));
				NGUIEditorTools.SetLabelWidth (80f);
				GUILayout.EndHorizontal ();

				GUILayout.BeginHorizontal ();
				NGUIEditorTools.SetLabelWidth (50f);
				GUILayout.Space (79f);
				NGUIEditorTools.DrawProperty (_ui.dir == GradientUISprite.GradientDirection.Vertical ? "Bottom" : "Right", serializedObject, "mgradientBottom", GUILayout.MinWidth (40f));
				NGUIEditorTools.SetLabelWidth (80f);
			}
			EditorGUI.EndDisabledGroup ();
			GUILayout.EndHorizontal ();
			if (NGUISettings.unifiedTransform) {
				DrawColor (serializedObject, mWidget);
			} else
				DrawInspectorProperties (serializedObject, mWidget, !gr.boolValue);
		}
	
	}
} // namespace EditorTool
