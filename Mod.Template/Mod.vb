Imports Reactor.API.Attributes
Imports Reactor.API.Interfaces.Systems
Imports Reactor.API.Logging
Imports Reactor.API.Runtime.Patching
Imports UnityEngine

Namespace Distance.ModTemplate
	''' <summary>
	''' The Mod's main class containing its entry point
	''' </summary>
	<ModEntryPoint("<INSERT MOD UNIQUE ID HERE>")>
	Public NotInheritable Class [Mod]
		Inherits MonoBehaviour

		Public Shared Instance As [Mod]

		Public Property Manager As IManager

		Public Property Logger As Log

		''' <summary>
		''' Method called as soon as the Mod Is loaded.
		''' WARNING:	Do Not load asset bundles/textures in this function
		'''				The unity assets systems are Not yet loaded when this
		'''				function Is called. Loading assets here can lead to
		'''				unpredictable behaviour And crashes!
		''' </summary>
		Public Sub Initialize(manager As IManager)
			' Do not destroy the current game object when loading a new scene
			DontDestroyOnLoad(Me)

			Instance = Me

			Me.Manager = manager

			' Create a log file
			Logger = LogManager.GetForCurrentAssembly()

			Logger.Info("Hello World!")

			RuntimePatcher.AutoPatch()
		End Sub

		''' <summary>
		''' Method called after
		''' <c>GameManager.Start()</c>
		''' This initialisation method Is the same as
		''' the Spectrum Mod loader initialisation procedure.
		''' </summary>
		Public Sub LateInitialize(manager As IManager)
			' Code here...
			Initialize(manager)
		End Sub
	End Class
End Namespace