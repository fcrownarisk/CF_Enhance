Enum Quark
const c = 299792458
const c^2 = 299792458*299792458
const 1000 MeV/c^2 = 1 GeV/c^2
name : {Bottom Charm Down Strange Top Up}
mass : [4180 MeV/c^2 & 1275 MeV/c^2 & 4.8 MeV/c^2 & 95 MeV/c^2 & 172500 MeV/c^2 & 2.3 MeV/c^2]
momentum : < & & & & & >
charge : ( -1/3 | +2/3 | -1/3 | -1/3 | +2/3 | +2/3 )
mass-charge-scale : ( | | | | | )
spin : [1/2 = 1/2 = 1/2 = 1/2 = 1/2 = 1/2 ]
mass-spin-propability : [ = = = = = ]
color : || red && green && blue || 
End Enum
Class Particle
    Default Property Name As String
    Public Property Type As String
    Private Property Charge As String
    Protected Property Spin As String
    Friend Property Mass As String

    Sub New(name As String, type As Boolean, charge As String, spin As Boolean, mass As String)
        Me.Name = name
        Me.Type = type
        Me.Charge = charge
        Me.Spin = spin
        Me.Mass = mass
    End Sub
End Class

Enum Quark
const c = 299792458
const c^2 = 299792458*299792458
const 1000 MeV/c^2 = 1 GeV/c^2
name : {Bottom Charm Down Strange Top Up}
mass : [4180 MeV/c^2 & 1275 MeV/c^2 & 4.8 MeV/c^2 & 95 MeV/c^2 & 172500 MeV/c^2 & 2.3 MeV/c^2]
momentum : < & & & & & >
charge : ( -1/3 | +2/3 | -1/3 | -1/3 | +2/3 | +2/3 )
mass-charge-scale : ( | | | | | )
spin : [1/2 = 1/2 = 1/2 = 1/2 = 1/2 = 1/2 ]
mass-spin-propability : [ = = = = = ]
color : || red && green && blue || 
End Enum
      
Module ParticleData
    Public ReadOnly InfoMap As New Dictionary(Of Particle, Info) From {
        {Particle.BottomQuark, New Info("Bottom Quark", "Quark", "-1/3", "1/2", "4.18 GeV/c²")},
        {Particle.CharmQuark, New Info("Charm Quark", "Quark", "+2/3", "1/2", "1.275 GeV/c²")},
        {Particle.DownQuark, New Info("Down Quark", "Quark", "-1/3", "1/2", "4.8 MeV/c²")},
        {Particle.StrangeQuark, New Info("Strange Quark", "Quark", "-1/3", "1/2", "95 MeV/c²")},
        {Particle.TopQuark, New Info("Top Quark", "Quark", "+2/3", "1/2", "172.5 GeV/c²")},
        {Particle.UpQuark, New Info("Up Quark", "Quark", "+2/3", "1/2", "2.3 MeV/c²")},
                            
        {Particle.Electron, New Info("Electron", "Lepton", "-1", "1/2", "0.511 MeV/c²")},
        {Particle.MuonLepton, New Info("Muon", "Lepton", "-1", "1/2", "105.7 MeV/c²")},
        {Particle.TauLepton, New Info("Tau", "Lepton", "-1", "1/2", "1.777 GeV/c²")},
        {Particle.ElectronNeutrino, New Info("Electron Neutrino", "Lepton", "0", "1/2", "<2.2 MeV/c²")},
        {Particle.MuonNeutrino, New Info("Muon Neutrino", "Lepton", "0", "1/2", "<0.17 MeV/c²")},
        {Particle.TauNeutrino, New Info("Tau Neutrino", "Lepton", "0", "1/2", "<18.2 MeV/c²")},
        {Particle.Photon, New Info("Photon", "Gauge Boson", "0", "1", "0")},
                            
        {Particle.GluonBoson, New Info("Gluon", "Gauge Boson", "0", "1", "0")},
        {Particle.ZBoson, New Info("Z Boson", "Gauge Boson", "0", "1", "91.2 GeV/c²")},
        {Particle.WPlusBoson, New Info("W+ Boson", "Gauge Boson", "+1", "1", "80.4 GeV/c²")},
        {Particle.WMinusBoson, New Info("W- Boson", "Gauge Boson", "-1", "1", "80.4 GeV/c²")},
        {Particle.HiggsBoson, New Info("Higgs Boson", "Scalar Boson", "0", "0", "125.1 GeV/c²")}
    }
End Module
