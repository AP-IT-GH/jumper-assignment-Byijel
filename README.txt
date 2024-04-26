# Jumper ML-Agents oefening
## Inleiding

In de ML-Agent 'Jumper' uitdaging wordt een kubus uitgedaagd om over muren (balken) te springen en mogelijk ook enkele bollen (spheres) te verzamelen voor extra punten. Het bestraffen van onnodig springen gebeurt door een kleine aftrek van punten, terwijl stilstaan juist beloond wordt met een kleine toevoeging van punten. Het hoofddoel is om de kubus zo lang mogelijk punten te laten vergaren zonder tegen een muur aan te botsen. Zodra de kubus een muur raakt, wordt de huidige training afgesloten. Het vermijden van elk contact met muren is dus van essentieel belang.

Om dit project na te maken volg je de volgende stappen:

1. Maak een jumper omgeving waar je een platform hebt met daar op een agent. aan de ander kant van het platform zet je een empty game object, hier gaan de obstacels uit spawnen.
    ![setup](./Images/JumperPrefab)
2. Hierna gaan we het obstacel prefab maken. Deze bevat een obstacel en een extra rechthoek er achter dat als reward dient.



