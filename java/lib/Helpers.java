package lib;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.Arrays;

public class Helpers {
    public static boolean isValidCategory(String category) {
        return Arrays.asList(Constants.ALLOWED_CATEGORIES).contains(category);
    }

    public static String getJSONData(String category) throws IOException, InterruptedException {

        HttpClient client = HttpClient.newHttpClient();
        HttpRequest request = HttpRequest.newBuilder().uri(URI.create(Constants.BASE_URL + category)).build();
        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());

        return response.body();
    }
}