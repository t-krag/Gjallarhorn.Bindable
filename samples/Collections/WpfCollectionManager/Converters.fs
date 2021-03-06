﻿namespace CollectionManager.Views

open CollectionSample
open System.Windows
open System.Windows.Media

module internal Converters =    
    let makeBrush (color : Color) =
        let lgb = LinearGradientBrush(StartPoint = Point(0.0, 0.0), EndPoint = Point(1.0, 0.0))
        GradientStop(color, 0.0) |> lgb.GradientStops.Add
        GradientStop(color, 0.02) |> lgb.GradientStops.Add
        GradientStop(Colors.Transparent, 0.35) |> lgb.GradientStops.Add
        GradientStop(Colors.Transparent, 1.0) |> lgb.GradientStops.Add
        lgb :> Brush
    let statusToColor status _ =
        match status with
        | Request.Accepted -> Colors.Green
        | Request.Rejected -> Colors.Red
        | Request.Unknown -> Colors.Transparent    
        |> makeBrush

type StatusToColorConverter () =
     inherit FsXaml.Converter<Request.Status, Brush>(Converters.statusToColor, Brushes.Transparent)
