﻿using UnityEngine;

/// <summary>
/// Allows an object to be pet by a player. Shameless copy of Huggable.cs
/// </summary>
public class Pettable : MonoBehaviour, ICheckedInteractable<PositionalHandApply>
{
	public bool WillInteract( PositionalHandApply interaction, NetworkSide side )
	{
		var targetNPCHealth = interaction.TargetObject.GetComponent<LivingHealthBehaviour>();
		var performerPlayerHealth = interaction.Performer.GetComponent<PlayerHealth>();
		var performerRegisterPlayer = interaction.Performer.GetComponent<RegisterPlayer>();

		// Is the target in range for a pet? Is the target conscious for the pet? Is the performer's intent set to help?
		// Is the performer's hand empty? Is the performer not stunned/downed? Is the performer conscious to perform the interaction?
		// Is the performer interacting with itself?
		if (!Validations.CanApply(interaction.Performer, interaction.TargetObject, side, true, ReachRange.Standard, interaction.TargetVector))
		{
			return false;
		}

		Chat.AddActionMsgToChat(interaction.Performer,
	$"You pet {interaction.TargetObject.name}.", $"{interaction.Performer.ExpensiveName()} pets {interaction.TargetObject.name}.");
		return true;
	}
}
