﻿using System.Collections.ObjectModel;
using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Admins;

public class Admin : AggregateRoot<Guid>
{
    private readonly IList<PlebRegistrationRequest> _plebRegistrationRequests;
    private readonly IList<Decision> _decisions;
    public string ProfileName { get; }

    private Admin(string profileName, Guid id) : base(id)
    {
        ProfileName = profileName;
        _plebRegistrationRequests = new List<PlebRegistrationRequest>();
        _decisions = new List<Decision>();
    }

    public void AddPlebRequest(PlebRegistrationRequest plebRegistrationRequest)
    {
        _plebRegistrationRequests.Add(plebRegistrationRequest);
    }

    public void AddDecision(Decision decision)
    {
        _decisions.Add(decision);
    }

    public static Admin Create(string profileName)
    {
        return new Admin(profileName, Guid.NewGuid());
    }

    public static Admin Create(string profileName, Guid id)
    {
        return new Admin(profileName, id);
    }

    public IReadOnlyList<PlebRegistrationRequest> PlebRegistrationRequests =>
        new List<PlebRegistrationRequest>(_plebRegistrationRequests).AsReadOnly();

    public IReadOnlyList<Decision> Decisions =>
        new List<Decision>(_decisions).AsReadOnly();
}