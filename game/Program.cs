// See https://aka.ms/new-console-template for more information
using gameFramework.models;
using System.Reflection;

Console.WriteLine("Hello, World!");

//Reflection accesing property
Creature creature = new Creature();
PropertyInfo property = creature.GetType().GetProperty("HitPoints");
int hitPoints = (int)property.GetValue(creature);

