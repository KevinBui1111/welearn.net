namespace welearn.net.play.Doodle.Support;

using Microsoft.Web.XmlTransform;

public readonly record struct Result(bool IsSuccess, string? Error) {
    public static Result Success() => new(true, null);
    public static Result Success(string error) => new(true, error);
    public static Result Failure(string error) => new(false, error);
}

public static class XmlTrans {
    public static void Apply(string env, params string[] configFiles) {
        foreach (var configFile in configFiles) {
            var result = ApplyXmlTransform(configFile, env);
            Console.WriteLine(result.Error);
        }
    }

    public static Result ApplyXmlTransform(string sourcePath, string env) {
        var dir = Path.GetDirectoryName(sourcePath);
        var filename = Path.GetFileName(sourcePath);
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourcePath);
        var extension = Path.GetExtension(sourcePath);
        var configFile = Path.Combine(dir ?? string.Empty, $"{fileNameWithoutExtension}.{env}{extension}");

        if (!File.Exists(configFile))
            return Result.Failure($"Config file for environment '{env}' not found: {configFile}");

        var destFilename = $"{filename}.{env}";
        var destPath = Path.Combine(dir ?? string.Empty, destFilename);
        var result = ApplyXmlTransform(sourcePath, configFile, destPath);

        return result.IsSuccess
            ? Result.Success($"Applied transform for environment '{env}': {filename} -> {destFilename}")
            : Result.Failure($"Failed to apply transform for environment '{env}': {filename}");
    }

    public static Result ApplyXmlTransform(string sourcePath, string transformPath, string destPath) {
        using var document = new XmlTransformableDocument();
        document.PreserveWhitespace = true;
        document.Load(sourcePath);

        using var transformation = new XmlTransformation(transformPath);
        if (!transformation.Apply(document))
            return Result.Failure("Transformation failed to apply.");

        document.Save(destPath);
        return Result.Success();
    }
}